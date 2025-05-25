Create Schema WestGate;
Use WestGate;
CREATE TABLE Region (
    region_id INT AUTO_INCREMENT PRIMARY KEY,
    province VARCHAR(100),
    city VARCHAR(100),
    district VARCHAR(100),
    zone_name VARCHAR(100)
);

CREATE TABLE School (
    school_id INT AUTO_INCREMENT PRIMARY KEY,
    region_id INT,
    established_year INT,
    school_type VARCHAR(100),
    status VARCHAR(50),
    address VARCHAR(255),
    area_size_mu FLOAT,
    building_area_m2 FLOAT,
    website VARCHAR(255),
    FOREIGN KEY (region_id) REFERENCES Region(region_id)
);

CREATE TABLE SchoolTranslation (
    school_id INT Primary Key,
    lang_code VARCHAR(5),
    name VARCHAR(255),
    description TEXT,
    philosophy TEXT,
    facilities TEXT,
    UNIQUE (school_id, lang_code),
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE SchoolLevel (
    level_id INT AUTO_INCREMENT PRIMARY KEY,
    school_id INT,
    level_name ENUM('Kindergarten', 'Primary', 'Junior', 'Senior'),
    start_grade INT,
    end_grade INT,
    num_classes INT,
    num_students INT,
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE Program (
    program_id INT AUTO_INCREMENT PRIMARY KEY,
    level_id INT,
    curriculum_code VARCHAR(100),
    language_of_instruction VARCHAR(100),
    student_capacity INT,
    class_size_range VARCHAR(100),
    FOREIGN KEY (level_id) REFERENCES SchoolLevel(level_id)
);

CREATE TABLE ProgramTranslation (
    program_id INT Primary Key,
    lang_code VARCHAR(5),
    program_name VARCHAR(255),
    curriculum_details TEXT,
    UNIQUE (program_id, lang_code),
    FOREIGN KEY (program_id) REFERENCES Program(program_id)
);

CREATE TABLE GraduateDestination (
    destination_id INT AUTO_INCREMENT PRIMARY KEY,
    school_id INT,
    country VARCHAR(100),
    num_students INT,
    year INT,
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE Accreditation (
    accreditation_id INT AUTO_INCREMENT PRIMARY KEY,
    school_id INT,
    organization_name VARCHAR(100),
    certified BOOLEAN,
    certification_date DATE,
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE SchoolImage (
    image_id INT AUTO_INCREMENT PRIMARY KEY,
    school_id INT,
    image_url VARCHAR(255),
    caption VARCHAR(255),
    upload_date DATE,
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE ManagementTeam (
    member_id INT AUTO_INCREMENT PRIMARY KEY,
    school_id INT,
    name VARCHAR(100),
    position VARCHAR(100),
    bio TEXT,
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE User (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(255) UNIQUE,
    password_hash VARCHAR(255),
    role ENUM('admin', 'editor', 'viewer'),
    created_at DATETIME
);

CREATE TABLE UserProfile (
    profile_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    full_name VARCHAR(100),
    avatar_url VARCHAR(255),
    bio TEXT,
    phone VARCHAR(50),
    FOREIGN KEY (user_id) REFERENCES User(user_id)
);

CREATE TABLE NewsPost (
    post_id INT AUTO_INCREMENT PRIMARY KEY,
    school_id INT,
    author_id INT,
    published_at DATETIME,
    FOREIGN KEY (school_id) REFERENCES School(school_id),
    FOREIGN KEY (author_id) REFERENCES User(user_id)
);

CREATE TABLE NewsPostTranslation (
    id INT AUTO_INCREMENT PRIMARY KEY,
    post_id INT,
    lang_code VARCHAR(5),
    title VARCHAR(255),
    content TEXT,
    UNIQUE (post_id, lang_code),
    FOREIGN KEY (post_id) REFERENCES NewsPost(post_id)
);

CREATE TABLE VisitLog (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    school_id INT,
    visit_time DATETIME,
    action_type ENUM('view', 'edit', 'comment'),
    FOREIGN KEY (user_id) REFERENCES User(user_id),
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);
CREATE SCHEMA IF NOT EXISTS WestGate;
USE WestGate;

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
    school_id INT,
    lang_code VARCHAR(5),
    name VARCHAR(255),
    description TEXT,
    philosophy TEXT,
    facilities TEXT,
    PRIMARY KEY (school_id, lang_code),
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

-- Unified User table
CREATE TABLE User (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(255) UNIQUE,
    password_hash VARCHAR(255),
    full_name VARCHAR(100),
    avatar_url VARCHAR(255),
    bio TEXT,
    phone VARCHAR(50),
    created_at DATETIME
);

-- Subclasses
CREATE TABLE AdminUser (
    user_id INT PRIMARY KEY,
    FOREIGN KEY (user_id) REFERENCES User(user_id)
);

CREATE TABLE ManagementUser (
    user_id INT PRIMARY KEY,
    institution VARCHAR(255),
    FOREIGN KEY (user_id) REFERENCES User(user_id)
);

CREATE TABLE ViewerUser (
    user_id INT PRIMARY KEY,
    FOREIGN KEY (user_id) REFERENCES User(user_id)
);

CREATE TABLE NewsPost (
    post_id INT AUTO_INCREMENT PRIMARY KEY,
    school_id INT,
    published_at DATETIME,
    FOREIGN KEY (school_id) REFERENCES School(school_id)
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

-- Logs for content editing (post)
CREATE TABLE ContentEditLog (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    post_id INT,
    action TEXT,
    log_time DATETIME,
    FOREIGN KEY (user_id) REFERENCES ManagementUser(user_id),
    FOREIGN KEY (post_id) REFERENCES NewsPost(post_id)
);

-- Logs for school editing
CREATE TABLE SchoolEditLog (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    school_id INT,
    action TEXT,
    log_time DATETIME,
    FOREIGN KEY (user_id) REFERENCES ManagementUser(user_id),
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE VisitLog (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    school_id INT,
    visit_time DATETIME,
    action_type ENUM('view', 'edit', 'comment'),
    FOREIGN KEY (user_id) REFERENCES ViewerUser(user_id),
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE Kindergarten (
    sub_id INT,
    school_id INT,
    name VARCHAR(255),
    student_count INT,
    PRIMARY KEY (school_id, sub_id),
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE PrimarySchool (
    sub_id INT,
    school_id INT,
    name VARCHAR(255),
    student_count INT,
    PRIMARY KEY (school_id, sub_id),
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE JuniorHighSchool (
    sub_id INT,
    school_id INT,
    name VARCHAR(255),
    student_count INT,
    PRIMARY KEY (school_id, sub_id),
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE HighSchool (
    sub_id INT,
    school_id INT,
    name VARCHAR(255),
    student_count INT,
    PRIMARY KEY (school_id, sub_id),
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);

CREATE TABLE AnonymousVisitLog (
    id SERIAL PRIMARY KEY,
    session_id VARCHAR(255) NOT NULL,
    ip_address VARCHAR(45),
    user_agent TEXT,
    referrer TEXT,
    page_url TEXT,
    school_id INT,
    action_type ENUM('view', 'comment', 'search'),
    visit_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (school_id) REFERENCES School(school_id)
);
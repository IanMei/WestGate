Use WestGate;

-- Basic Content Check

-- Base tables
SELECT * FROM Region;
SELECT * FROM School;
SELECT * FROM SchoolTranslation;
SELECT * FROM GraduateDestination;
SELECT * FROM Accreditation;
SELECT * FROM SchoolImage;

-- User-related tables
SELECT * FROM User;
SELECT * FROM AdminUser;
SELECT * FROM ManagementUser;
SELECT * FROM ViewerUser;

-- News and content editing logs
SELECT * FROM NewsPost;
SELECT * FROM NewsPostTranslation;
SELECT * FROM ContentEditLog;
SELECT * FROM SchoolEditLog;

-- User activity tracking
SELECT * FROM VisitLog;
SELECT * FROM AnonymousVisitLog;

-- Sub-school level tables
SELECT * FROM Kindergarten;
SELECT * FROM PrimarySchool;
SELECT * FROM JuniorHighSchool;
SELECT * FROM HighSchool;

-- Single table
-- Where
SELECT school_id, school_name, established_year, school_type
FROM School
WHERE established_year > 2010;

-- Like
SELECT user_id, full_name, email
FROM User
WHERE email LIKE '%@test.com%';

-- Order By
SELECT destination_id, school_id, country, num_students
FROM GraduateDestination
ORDER BY num_students,school_id DESC;

-- AND
SELECT school_id, school_name, established_year, school_type, status
FROM School
WHERE status = 'active' AND established_year > 2010;

-- OR
SELECT school_id, school_name, region_id, school_type
FROM School
WHERE school_type = 'IB' OR region_id = 2;

-- IN
SELECT school_id, school_name, region_id
FROM School
WHERE region_id IN (2, 4, 5);

-- BETWEEN
SELECT school_id, school_name, area_size_mu
FROM School
WHERE area_size_mu BETWEEN 30 AND 70;

-- GROUP BY with AVG
SELECT region_id, AVG(building_area_m2) AS avg_building_area
FROM School
GROUP BY region_id;

-- GROUP BY with SUM
SELECT region_id, SUM(area_size_mu) AS total_area_mu
FROM School
GROUP BY region_id;

-- GROUP BY with COUNT
SELECT school_type, COUNT(*) AS total_schools
FROM School
GROUP BY school_type;

-- GROUP BY with HAVING
SELECT region_id, COUNT(*) AS school_count
FROM School
GROUP BY region_id
HAVING COUNT(*) > 3;


-- Multi Table

-- 1. INNER JOIN: School with Region
SELECT s.school_id, s.school_name, r.city, r.province
FROM School s
JOIN Region r ON s.region_id = r.region_id;

-- 2. LEFT JOIN: Show all schools and their graduation destinations (if any)
SELECT s.school_id, s.school_name, g.country, g.num_students
FROM School s
LEFT JOIN GraduateDestination g ON s.school_id = g.school_id;

-- 3. RIGHT JOIN: Show all graduate destinations and their schools (if any)
SELECT g.destination_id, s.school_name, g.country, g.year
FROM GraduateDestination g
RIGHT JOIN School s ON g.school_id = s.school_id;

-- 4. FULL OUTER JOIN simulation using UNION
SELECT s.school_id, s.school_name, g.country
FROM School s
LEFT JOIN GraduateDestination g ON s.school_id = g.school_id
UNION
SELECT s.school_id, s.school_name, g.country
FROM GraduateDestination g
RIGHT JOIN School s ON g.school_id = s.school_id;

-- 5. UNION: Combine IB and AP schools into one list
SELECT school_id, school_name, school_type
FROM School
WHERE school_type = 'IB'
UNION
SELECT school_id, school_name, school_type
FROM School
WHERE school_type = 'AP';

-- 6. GROUP BY + HAVING: Count schools per region, show only where more than 2 schools
SELECT region_id, COUNT(*) AS school_count
FROM School
GROUP BY region_id
HAVING COUNT(*) > 2;

-- 7. Subquery with MAX: School with the largest building area
SELECT school_id, school_name, building_area_m2
FROM School
WHERE building_area_m2 = (
    SELECT MAX(building_area_m2)
    FROM School
);

-- 8. EXISTS: Schools that have news posts
SELECT s.school_id, s.school_name
FROM School s
WHERE EXISTS (
    SELECT 1
    FROM NewsPost n
    WHERE n.school_id = s.school_id
);

-- 9. JOIN across 3 tables: NewsPost + NewsPostTranslation + School
SELECT n.post_id, st.school_name, t.lang_code, t.title
FROM NewsPost n
JOIN NewsPostTranslation t ON n.post_id = t.post_id
JOIN School st ON st.school_id = n.school_id;

-- 10. Multi-table JOIN with filter: Show schools with certified accreditation
SELECT s.school_id, s.school_name, a.organization_name, a.certified
FROM School s
JOIN Accreditation a ON s.school_id = a.school_id
WHERE a.certified = 1;
-------------------------------------------------------------------------------2
/*
-----------------------------------------------------------A
SELECT d.firstname + ' ' + d.lastname AS Director, 
	COUNT(m.movie_no) AS [Number of movies]
FROM MM_DIRECTOR d, MM_MOVIE m
WHERE d.director_no = m.dir_director_no
GROUP BY d.firstname + ' ' + d.lastname
ORDER BY COUNT(m.movie_no) desc;
*/
/*
-----------------------------------------------------------B
SELECT d.firstname + ' ' + d.lastname AS Director, 
	YEAR(GETDATE()) - d.birth_year AS Age,
	'Director' AS Occupation
FROM MM_DIRECTOR d WHERE d.death_year is null 
	union
SELECT s.firstname + ' ' + s.lastname AS Director, 
	YEAR(GETDATE()) - s.birth_year AS Age,
	'Actor' AS Occupation
FROM MM_MOVIE_STAR s WHERE s.death_year is null 
ORDER BY Age;
*/

/*
-------------------------------------------------------------------------------3
Insert into MM_MOVIE_STAR (STAR_NO,LASTNAME,FIRSTNAME,BIRTH_PLACE,BIRTH_YEAR,DEATH_YEAR) values (31,'Philip','Dumaresq','Ottawa',1998,2015);
Insert into MM_MOVIE_MOVIE_STAR (MOV_MOVIE_NO,MS_STAR_NO) values (27,31);
*/

-------------------------------------------------------------------------------4
DECLARE
	@lv_fname varchar(25);
	SET @lv_fname='Woody';
DECLARE
	@lv_lname varchar(25);
	SET @lv_lname='Allen';
BEGIN
	DELETE FROM MM_MOVIE_MOVIE_STAR
	WHERE mov_movie_no = ANY(
		SELECT MOVIE_NO FROM MM_MOVIE 
		WHERE dir_director_no = (
			SELECT d.director_no 
			FROM MM_DIRECTOR d
			WHERE d.firstname = @lv_fname AND d.lastname = @lv_lname
		)
	);
	
	DELETE FROM MM_MOVIE
	WHERE DIR_DIRECTOR_NO = (
		SELECT d.director_no 
		FROM MM_DIRECTOR d
			WHERE d.firstname = @lv_fname AND d.lastname = @lv_lname
	);
END


	


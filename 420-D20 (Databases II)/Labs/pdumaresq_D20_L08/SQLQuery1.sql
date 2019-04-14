CREATE VIEW new_view AS
SELECT a.albumName, aa.ArtistName, a.releaseDate, g.genre
	FROM albums a, artist aa, genres g
	WHERE a.artistId = aa.artistid
	AND a.genreid = g.genreid;

SELECT * FROM new_view
WHERE ReleaseDate >= dateadd(year, -10, SYSDATETIME())
	AND genre = 'Rock';

SELECT genre, count(albumName) AS NumAlbums
FROM new_view
WHERE ReleaseDate >= dateadd(year, -10, SYSDATETIME())
group by genre
ORDER BY count(albumName) desc;

DROP PROCEDURE GenreCount_sp;
CREATE PROCEDURE GenreCount_sp 
AS
	SELECT genre, count(albumName) AS NumAlbums
	FROM new_view
	WHERE ReleaseDate >= dateadd(year, -3, SYSDATETIME())
	group by genre
	ORDER BY count(albumName) desc;
GO

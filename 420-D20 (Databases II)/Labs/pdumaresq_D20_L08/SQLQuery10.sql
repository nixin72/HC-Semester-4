SELECT aa.artistName, a.albumName, g.genre, a.releaseDate
FROM Albums a, Artist aa, Genres g
WHERE a.artistid = aa.artistid
  AND a.genreid  = g.genreid
  AND ReleaseDate >= dateadd(year, -10, SYSDATETIME())
ORDER BY ArtistName, albumName, ReleaseDate;


SELECT g.genre, count(a.albumid) 
FROM Albums a, Genres g
WHERE a.genreid = g.genreid
GROUP BY g.Genre
ORDER BY count(a.albumid) desc;
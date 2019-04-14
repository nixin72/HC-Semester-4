---
--- Demonstrate implict cursor
--- 1) implicit cursor attributes
--- If 420B20 doesn't exist, what do you think the output would look like?

BEGIN
-- Change the prereq of course 420B20 to 420B10
   UPDATE iu_course
      SET prereq = '420B10'
    WHERE courseid = '420B20';

   DBMS_OUTPUT.put_line ('After UPDATE, cursor attributes are: ');
   DBMS_OUTPUT.put_line ('    SQL%ROWCOUNT: ' || SQL%ROWCOUNT);

   IF SQL%FOUND
   THEN
      DBMS_OUTPUT.put_line ('    FOUND: true');
   ELSE
      DBMS_OUTPUT.put_line ('    FOUND: false');
   END IF;

   IF SQL%NOTFOUND
   THEN
      DBMS_OUTPUT.put_line ('    NOTFOUND: true');
   ELSE
      DBMS_OUTPUT.put_line ('    NOTFOUND: false');
   END IF;

   -- If the previous UPDATE statement didn't match any rows,
   -- add a new row to the course table.
   IF SQL%NOTFOUND
   THEN
      INSERT INTO iu_course (courseid, title, credits, prereq)
           VALUES ('420B20', 'Programming II', 3, '420B10' );

      DBMS_OUTPUT.put_line ('After INSERT, cursor attributes are: ');
      DBMS_OUTPUT.put_line ('    ROWCOUNT: ' || SQL%ROWCOUNT);

      IF SQL%FOUND
      THEN
         DBMS_OUTPUT.put_line ('    FOUND: true');
      ELSE
         DBMS_OUTPUT.put_line ('    FOUND: false');
      END IF;

      IF SQL%NOTFOUND
      THEN
         DBMS_OUTPUT.put_line ('    NOTFOUND: true');
      ELSE
         DBMS_OUTPUT.put_line ('    NOTFOUND: false');
      END IF;
   END IF;
END;


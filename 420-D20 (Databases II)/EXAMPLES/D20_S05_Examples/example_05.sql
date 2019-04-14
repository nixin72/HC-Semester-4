---
--- Demonstrate two flavours of FOR loop with cursor
--- same solution with two variants:
--- 1) explicitly declared cursor
--- 2) implicitly declared cursor
--- 


--- variant 1: explicitly declared cursor in FOR loop
SET serveroutput ON
DECLARE
   CURSOR lcur_cs_students
   IS
      SELECT s.studentid, s.FIRST, s.LAST
        FROM iu_student s, iu_major m
       WHERE s.majorid = m.majorid
         AND UPPER (m.majordesc) = 'AAS=COMPUTER SCIENCE';
BEGIN
   -- Begin the loop. 
   FOR lrec_studentdata IN lcur_cs_students
   LOOP
      -- An implicit FETCH is done here, and %NOTFOUND is checked

      -- Process the fetched rows, in this case sign up each
      -- student for Database Systems by inserting them into the
      -- registration table. Record the first and last
      -- names in temp_table as well.
      INSERT INTO iu_registration (studentid, csid )
           VALUES (lrec_studentdata.studentid, 1208 );

      INSERT INTO temp_table (num_col, char_col )
           VALUES (lrec_studentdata.studentid,
                   lrec_studentdata.FIRST || ' ' || lrec_studentdata.LAST);
   END LOOP;
-- Now that the loop is finished, an implicit CLOSE is done.
END;

---
--- variant 2: implicitly declared cursor in FOR loop
---
  -- Begin the loop. An implicit OPEN is done here.

  FOR lrec_studentdata IN (SELECT s.studentid, s.FIRST, s.LAST
                           FROM iu_student s, iu_major m
                          WHERE s.majorid = m.majorid
                           AND UPPER (m.majordesc) = 'AAS=COMPUTER SCIENCE')
  LOOP
     INSERT INTO iu_registration
                 (studentid, csid )
          VALUES (lrec_studentdata.studentid, 1208 );

     INSERT INTO temp_table (num_col, char_col)
          VALUES (lrec_studentdata.studentid,
                  lrec_studentdata.FIRST || ' ' || lrec_studentdata.LAST);
  END LOOP;
-- Now that the loop is finished, an implicit CLOSE is done.
END;


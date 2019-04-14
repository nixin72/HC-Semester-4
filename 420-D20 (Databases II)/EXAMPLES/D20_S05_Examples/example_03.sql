---
--- Demonstrate an explicit cursor
--- Read and display the building, office and phone
--- number for all faculty members.
---
--- 1) basic "while" loop
--- 2) cursor
--- 3) record
---
--- note lifecycle of a cursor:
--- 1) DECLARE
--- 2) OPEN
--- 3) FETCH
--- 4) Close
--- 
SET serveroutput ON

DECLARE
   lv_final         iu_registration.FINAL%TYPE;
   lv_coursetitle   iu_course.title%TYPE;
   lv_studentid     iu_student.studentid%TYPE;
   lrec_student     iu_student%ROWTYPE;

   CURSOR lcur_final
   IS
      SELECT studentid, FINAL
        FROM iu_registration
       WHERE csid = 1102;
BEGIN
   -- get the course title for course section 1102
   SELECT title
     INTO lv_coursetitle
     FROM iu_course JOIN iu_crssection USING (courseid)
    WHERE csid = 1102;

   -- open the cursor
   OPEN lcur_final;

   LOOP
      -- get the final mark for the next student in course section 1102
      FETCH lcur_final
       INTO lv_studentid, lv_final;

      -- exit when there are no more records
      EXIT WHEN lcur_final%NOTFOUND;

      -- get the student record
      SELECT *
        INTO lrec_student
        FROM iu_student
       WHERE studentid = lv_studentid;

      -- display the results
      DBMS_OUTPUT.put_line (   lrec_student.FIRST || ' '
                            || lrec_student.last || ' got '
                            || lv_final
                            || ' in '
                            || lv_coursetitle
                           );
   END LOOP;

   CLOSE lcur_final;
END;

--- Note: you can only go through the active set with a cursor once.  
--- To process the returned rows more than once, close the cursor
--- and reopen it.
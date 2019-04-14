---
--- Demonstrate parameterized cursors
--- 1) using local variables
--- 2) using explicit parameters

 DECLARE
   lv_facultyid   iu_crssection.facultyid%TYPE;
   lv_courseid    iu_crssection.courseid%TYPE;

   CURSOR lcur_classes
   IS
      SELECT *
        FROM iu_crssection
       WHERE facultyid = lv_facultyid AND courseid = lv_courseid;
							-- lv_facultyid & lv_courseid have no values here
BEGIN
   lv_facultyid := 123;
   lv_courseid := 'CIS253';

   OPEN lcur_classes; -- lv_facultyid & lv_courseid have values here
   --- LOOP
     --- do  cursors stuff
	 --- fetch
	 --- exit when lcur_classes%NOT_FOUND;
    ---	 END LOOP;


	 
END;


---
---
--- Explicit parameters for cursors
--- 


DECLARE
   CURSOR lcur_classes (

      p_facultyid   iu_crssection.facultyid%TYPE,	
      p_courseid    iu_crssection.courseid%TYPE	
   )
   IS
      SELECT *
        FROM iu_crssection
       WHERE facultyid = p_facultyid AND courseid = p_courseid;
BEGIN
   OPEN lcur_classes (123, 'CIS253'); -- actual arguments
   --- LOOP
     --- do  cursors stuff
	 --- fetch
	 --- exit when lcur_classes%NOT_FOUND;
    ---	 END LOOP;
   
END;

   IS
      SELECT *
        FROM iu_crssection
       WHERE facultyid = p_facultyid AND courseid = p_courseid;
BEGIN
   OPEN lcur_classes (123, 'CIS253'); -- actual arguments
END;

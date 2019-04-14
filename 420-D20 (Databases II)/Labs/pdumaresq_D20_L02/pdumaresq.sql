--------------------------------------------------------------------------------
-----------------------------------PART A---------------------------------------
--------------------------------------------------------------------------------

SET SERVEROUTPUT ON;
DECLARE 
  lv_csid iu_crssection.CSID%TYPE;
  lv_csid_exists number := 0;
  lv_numStudents NUMBER;
  
  TYPE ltyp_temp
    IS RECORD (
      term IU_TERM.TERMDESC%TYPE,
      courseid IU_CRSSECTION.COURSEID%TYPE,
      courseName IU_COURSE.TITLE%TYPE,
      teacher IU_FACULTY.NAME%TYPE
    );
  lrec_crs ltyp_temp;
BEGIN
  lv_csid := &courseSectionId;
  SELECT count(*) INTO lv_csid_exists
    FROM iu_crssection
    WHERE csid = lv_csid;
    
  if (lv_csid_exists = 0) THEN
    DBMS_OUTPUT.PUT_LINE('The CSID does not exist');
  ELSE 
    SELECT t.termdesc, cs.courseid, c.title, f.name INTO lrec_crs
      FROM iu_crssection cs, iu_course c, iu_faculty f, iu_term t
      WHERE cs.csid = lv_csid --1101
        AND cs.facultyid = f.facultyid
        AND t.termid = cs.termid
        AND c.courseid = cs.courseid;
  
    SELECT count(studentid) INTO lv_numStudents
      FROM iu_registration
      WHERE csid = lv_csid;
          
    DBMS_OUTPUT.PUT_LINE('Course Section: ' || lv_csid || '  Term: ' || lrec_crs.term);
    DBMS_OUTPUT.PUT_LINE('Course: ' || lrec_crs.courseid || ' - ' || lrec_crs.coursename);
    DBMS_OUTPUT.PUT_LINE('Teacher: Professor ' || lrec_crs.teacher);
    DBMS_OUTPUT.PUT_LINE('Number of students: ' || lv_numStudents);
  
  END IF;
END;

DECLARE 
  lv_csid iu_crssection.CSID%TYPE;
  lv_csid_exists number := 0;
  lv_term IU_TERM.TERMDESC%TYPE;
  lv_courseid IU_CRSSECTION.COURSEID%TYPE;
  lv_courseName IU_COURSE.TITLE%TYPE;
  lv_teacher IU_FACULTY.NAME%TYPE;
  lv_numStudents NUMBER;
BEGIN
  lv_csid := &courseSectionId;
  SELECT count(*) INTO lv_csid_exists
    FROM iu_crssection
    WHERE csid = lv_csid;  
  
  if (lv_csid_exists = 0) THEN
    DBMS_OUTPUT.PUT_LINE('The CSID does not exist');
  ELSE 
    SELECT t.termdesc, cs.courseid, c.title, f.name 
      INTO lv_term, lv_courseid, lv_courseName, lv_teacher
      FROM iu_crssection cs, iu_course c, iu_faculty f, iu_term t
      WHERE cs.csid = lv_csid --1101
        AND cs.facultyid = f.facultyid
        AND t.termid = cs.termid
        AND c.courseid = cs.courseid;
      
    SELECT count(studentid) INTO lv_numStudents
      FROM iu_registration
      WHERE csid = lv_csid;

    DBMS_OUTPUT.PUT_LINE('Course Section: ' || lv_csid || '  Term: ' || lv_term);
    DBMS_OUTPUT.PUT_LINE('Course: ' || lv_courseid || ' - ' || lv_coursename);
    DBMS_OUTPUT.PUT_LINE('Teacher: Professor ' || lv_teacher);
    DBMS_OUTPUT.PUT_LINE('Number of students: ' || lv_numStudents);
  END IF;
END;


DECLARE 
  lrec_course IU_COURSE%ROWTYPE;
  lv_course_e NUMBER := 0;
  lv_courseid IU_COURSE.courseid%TYPE;
  lv_courseName IU_COURSE.title%TYPE;
  lv_prereqid IU_COURSE.prereq%TYPE;
  lv_sections NUMBER;
BEGIN
  lv_courseid := '&courseid';
  
  SELECT count(*) INTO lv_course_e
    FROM iu_course
    WHERE courseid = lv_courseid;
    
  IF lv_course_e = 1
    THEN
    SELECT * INTO lrec_course
    FROM iu_course
    WHERE courseid = lv_courseid;
    
    SELECT count(csid) INTO lv_sections
      FROM iu_crssection
      WHERE courseid = lv_courseid;
        
    lv_prereqid := lrec_course.prereq;
    lv_coursename := lrec_course.title;
        
    DBMS_OUTPUT.PUT_LINE('Course: ' || lv_courseid || ' ' ||lv_courseName);
    
    IF lv_prereqid IS NULL 
    THEN      DBMS_OUTPUT.PUT_LINE('No Prerequisits');
    ELSE      DBMS_OUTPUT.PUT_LINE('Prerequisite: ' || lv_prereqid);
    END IF;
    
    DBMS_OUTPUT.PUT_LINE('Number of sections: ' || lv_sections);
  else
    DBMS_OUTPUT.PUT_LINE('The course does not exist');
  end if;
END;


--------------------------------------------------------------------------------
-----------------------------------PART B---------------------------------------
--------------------------------------------------------------------------------

DECLARE
   lv_student_name   VARCHAR2 (25);
   lv_phone          CHAR (13);
   
   CURSOR lcur_student
   IS
      SELECT LAST ||', '|| FIRST student_name,
        '('|| SUBSTR(phone, 1, 3) ||')'|| SUBSTR(phone, 4, 3) ||'-'|| SUBSTR(phone, 7) student_phone
        FROM iu_student
       WHERE province = 'ON';
BEGIN
  OPEN lcur_student;
  DBMS_OUTPUT.put_line ('After open, rowcount is ' || lcur_student%ROWCOUNT );

  LOOP
    FETCH lcur_student
   	  INTO lv_student_name, lv_phone;
      DBMS_OUTPUT.put_line ('After fetch, rowcount is '|| lcur_student%ROWCOUNT );

      EXIT WHEN lcur_student%NOTFOUND;
      DBMS_OUTPUT.put_line (lv_student_name || ' ' || lv_phone);
   END LOOP;
   DBMS_OUTPUT.put_line ('Before close, rowcount is '|| lcur_student%ROWCOUNT );
   CLOSE lcur_student;
END;



DECLARE 
  lv_fname nn_employee.fname%TYPE;
  lv_lname nn_employee.lname%TYPE;
  lv_hire nn_employee.hiredate%TYPE;
  lv_salary nn_employee.salary%TYPE;
  
  CURSOR lcur_stuff
    IS SELECT fname, lname, hiredate, salary
      FROM nn_employee;
BEGIN
  OPEN lcur_stuff;
  LOOP
    FETCH lcur_stuff
      INTO lv_fname, lv_lname, lv_hire, lv_salary;
      
    EXIT WHEN lcur_stuff%NOTFOUND;
    IF lv_salary > 50000 and lv_hire < to_date('31-Dec-1997', 'dd-Month-YYYY')
      THEN
      DBMS_OUTPUT.PUT_LINE(lv_fname || ' ' || lv_lname 
          || ' was hired on ' || to_date(lv_hire, 'dd-Month-YY')
          || ' and has a salary of ' || to_char(lv_salary, '$999,999'));
    END IF;
  END LOOP;
  CLOSE lcur_stuff;
END;

--------------------------------------------------------------------------------
-----------------------------------PART C---------------------------------------
--------------------------------------------------------------------------------

DECLARE 
  CURSOR lcur_stuff
    IS SELECT fname, lname, hiredate, salary
      FROM nn_employee;
  lrec_emp lcur_stuff%ROWTYPE;
BEGIN
  FOR lrec_emp IN lcur_stuff LOOP      
    IF lrec_emp.salary > 50000 and lrec_emp.hiredate < to_date('31-Dec-1997', 'dd-Month-YYYY')
      THEN
      DBMS_OUTPUT.PUT_LINE(lrec_emp.fname || ' ' || lrec_emp.lname 
          || ' was hired on ' || to_date(lrec_emp.hiredate, 'dd-Month-YY')
          || ' and has a salary of ' || to_char(lrec_emp.salary, '$999,999'));
    END IF;
  END LOOP;
END;


DECLARE 
  lv_mfname nn_employee.fname%TYPE;
  lv_mlname nn_employee.lname%TYPE;
  
  CURSOR lcur_dept
    IS SELECT deptid, deptname, employeeid FROM nn_dept;
  lrec_dept lcur_dept%ROWTYPE;
BEGIN
  FOR lrec_dept IN lcur_dept LOOP
    SELECT fname, lname 
    INTO lv_mfname, lv_mlname
      FROM nn_employee
      WHERE employeeid = lrec_dept.employeeid;
  
    DBMS_OUTPUT.PUT_LINE('Department: ' || lrec_dept.deptid 
      || ' ' || lrec_dept.deptname || ' Manager: ' 
      || lv_mfname || ' ' || lv_mlname);
  END LOOP;
END;

--------------------------------------------------------------------------------
-----------------------------------PART D---------------------------------------
--------------------------------------------------------------------------------

DECLARE
  lv_total number:=0;
  CURSOR lcur_emp 
    IS SELECT fname, lname, salary + NVL(commission, 0) AS Salary
      FROM nn_employee
      ORDER BY lname;
  lrec_emp lcur_emp%ROWTYPE;
BEGIN
  OPEN lcur_emp;
  FETCH lcur_emp INTO lrec_emp;
  WHILE lcur_emp%FOUND LOOP
    lv_total := lv_total + lrec_emp.Salary;
    DBMS_OUTPUT.PUT_LINE(lrec_emp.fname || ' ' || lrec_emp.lname || ' earns ' 
        || to_char(lrec_emp.Salary, '$999,999'));
        
    FETCH lcur_emp INTO lrec_emp;
  END LOOP;
  DBMS_OUTPUT.PUT_LINE('-----------------------------------------');
  DBMS_OUTPUT.PUT_LINE('Company-Wide Compensation' || to_char(lv_total, '$999,999'));
  CLOSE lcur_emp;
END;

--PART A

--b
--i
SELECT cs.roomid 
  FROM iu_crssection cs
  INNER JOIN iu_location l
    on l.ROOMID = cs.ROOMID
  WHERE day like 'M%'
  and termid = 'SP03'
  and starttime = '09:00'
  and l.ROOMTYPE = 'C'
;
  
--ii
SELECT cs.csid, nvl(f.name, 'unassigned') AS "Teacher"
  FROM iu_crssection cs
  LEFT JOIN iu_faculty f
    on cs.facultyid = f.FACULTYID
;

--iii
SELECT REGEXP_REPLACE(e2.fname||' '||e2.lname, '^ $', 'No supervisor') AS "Supervisor", 
    e.fname||' '||e.lname AS "Employee"
  FROM nn_employee e
  LEFT JOIN NN_EMPLOYEE e2
    on e.supervisor = e2.employeeid
;


--B
--1
SET SERVEROUTPUT ON;
DECLARE
  num1 number;
BEGIN
  num1 := &Enter_a_number;
  
  DBMS_OUTPUT.PUT_LINE('The cube of '|| num1 || ' is ' || num1*num1*num1);
  DBMS_OUTPUT.PUT_LINE('The square of '|| num1 || ' is ' || num1*num1);
  DBMS_OUTPUT.PUT_LINE('Double '|| num1 || ' is ' || num1*2);
END;

--2
DECLARE 
  lv_hours number;
  lv_rate number;
  lc_tax CONSTANT NUMBER (3, 2) := 0.28;
  lv_gross_pay lv_rate % TYPE;
  lv_net_pay lv_rate % TYPE;
BEGIN
  lv_hours := &hours;
  lv_rate := &rate;
  lv_gross_pay := lv_hours * lv_rate;
  lv_net_pay := lv_gross_pay - (lv_gross_pay * lc_tax);
  
  DBMS_OUTPUT.PUT_LINE('Hours: ' || lv_hours);
  DBMS_OUTPUT.PUT_LINE('Pay Rate: ' || to_char(lv_rate, '$99.99'));
  DBMS_OUTPUT.PUT_LINE('Gross Pay: ' || to_char(lv_gross_pay, '$9,999.99'));
  DBMS_OUTPUT.PUT_LINE('Tax: ' || to_char(lv_gross_pay * lc_tax, '$9,999.99'));
  DBMS_OUTPUT.PUT_LINE('Net Pay: ' || to_char(lv_net_pay, '$9,999.99'));
END;

--3
DECLARE 
  lv_mark iu_registration.FINAL%TYPE;
  lv_fname iu_student.first%TYPE;
  lv_lname iu_student.last%TYPE;
  lv_course iu_course.title%TYPE;
BEGIN
  SELECT r.FINAL, s.first, s.last, c.title 
    into lv_mark, lv_fname, lv_lname, lv_course
    FROM iu_registration r, iu_student s, iu_course c, IU_CRSSECTION cs
    WHERE r.studentid = 100
      AND r.csid = 1104
      AND r.csid = cs.csid 
      AND cs.courseid = c.courseid
      AND r.studentid = s.studentid;
      
  DBMS_OUTPUT.PUT_LINE('Student name: ' || lv_fname ||' '|| lv_lname);
  DBMS_OUTPUT.PUT_LINE('Class: ' || lv_course);
  DBMS_OUTPUT.PUT_LINE('Mark: ' || lv_mark);
END;
--Part A
/*
--1
DROP TRIGGER nn_employee_bui_stmt_trg;
CREATE OR REPLACE TRIGGER nn_employee_bui_stmt_trg
BEFORE INSERT OR UPDATE ON NN_EMPLOYEE FOR EACH ROW
BEGIN
  IF to_char(:new.hiredate, 'DY') LIKE 'SUN' THEN
    RAISE_APPLICATION_ERROR(-20001, 'Can''t hire someone on a Sunday!!!');
  END IF;
END;

UPDATE nn_employee e 
  SET e.hiredate = to_date('19-Mar-17', 'dd-Mon-yy') 
  WHERE e.employeeid = 111;
 */ 
--2
/*
DROP TABLE iu_tracking;
CREATE TABLE iu_tracking ( 
  studentid 	varchar2(5),
  username 		varchar2(30),
  insertdate 	date
);


CREATE OR REPLACE TRIGGER iu_student_ai_trg
AFTER INSERT ON iu_student FOR EACH ROW
BEGIN
  INSERT INTO iu_tracking (
    studentid, username, insertdate
  ) VALUES (
    :new.studentid, :new.first || ' ' || :new.last, sysdate
  );
END;

INSERT INTO iu_student (
  studentid, first, last
) VALUES (
  999, 'philip', 'dumaresq'
);
*/

--3
/*
CREATE SEQUENCE nn_employee_seq 
  START WITH 600
  INCREMENT BY 1;
SET SERVEROUTPUT ON;

CREATE OR REPLACE TRIGGER nn_employee_bi_trg 
BEFORE INSERT ON nn_employee FOR EACH ROW 
DECLARE
  lv_empid nn_employee.employeeid%TYPE;
BEGIN
  SELECT nn_employee_seq.NEXTVAL INTO lv_empid FROM dual;
  
  :new.employeeid := lv_empid;
  :new.hiredate   := sysdate;
END nn_employee_bi_trg;

Insert into NN_EMPLOYEE (
  EMPLOYEEID, LNAME,  FNAME,      POSITIONID, SUPERVISOR,
  HIREDATE,   SALARY, COMMISSION, DEPTID,     QUALID
) values (
  1,                            'Philip', 'Dumaresq', 1,  null, 
  to_date('60-04-15','RR-MM-DD'), 265000,   35000,      20, 1
);

*/
--4
/*
UPDATE iu_student s
  SET creditsearned = (
    SELECT SUM(
      CASE WHEN FINAL IN ('A', 'B', 'C', 'D')
          THEN credits
      ELSE 0 END
    )
    FROM iu_course 
      JOIN iu_crssection USING (courseid) 
      JOIN iu_registration r USING (csid)
    WHERE r.studentid = s.studentid
  ); 
*/

/*
--5
CREATE OR REPLACE TRIGGER iu_registration_aidu_trg 
AFTER UPDATE OR INSERT OR DELETE ON iu_registration 
FOR EACH ROW
DECLARE 
  lv_credits IU_COURSE.CREDITS%TYPE;
BEGIN
SELECT c.credits into lv_credits
FROM iu_course c, iu_crssection crs
WHERE crs.csid = nvl(:new.csid, :old.csid)
  AND crs.COURSEID = c.courseid;

IF inserting THEN
  IF REGEXP_LIKE(:NEW.FINAL, '[A-D]') THEN    
    UPDATE iu_student s
      SET s.creditsEarned = s.creditsEarned + lv_credits;
  END IF;
ELSIF updating then
  IF REGEXP_LIKE(:OLD.FINAL, '[A-D]') THEN
    IF REGEXP_LIKE(:NEW.FINAL, '(F|W|X)') OR :NEW.FINAL IS NULL THEN      
      UPDATE iu_student s
        SET s.creditsEarned = s.creditsEarned - lv_credits;
    END IF;
  ELSE
    IF REGEXP_LIKE(:NEW.FINAL, '[A-D]') THEN      
      UPDATE iu_student s
        SET s.creditsEarned = s.creditsEarned + lv_credits;
    END IF;
  END IF;
ELSIF DELETING then
  IF REGEXP_LIKE(:OLD.FINAL, '[A-D]') THEN      
    UPDATE iu_student s
      SET s.creditsEarned = s.creditsEarned - lv_credits;
  END IF;
END IF;
END;
*/



--PART B
--1
CREATE OR REPLACE PROCEDURE get_student_final_sp(
    pv_csid_i IU_CRSSECTION.CSID%type,
    pv_cursor_o OUT SYS_REFCURSOR )
AS
BEGIN
  OPEN pv_cursor_o FOR 
  SELECT studentid, final 
  FROM iu_registration 
  WHERE csid = pv_csid_i;
END;

DECLARE
  lv_csid      iu_crssection.csid%TYPE;
  lv_cursor    SYS_REFCURSOR;
  lv_studentid iu_registration.STUDENTID%type;
  lv_final     iu_registration.FINAL%TYPE;
BEGIN
  lv_csid := &CSID;
  get_student_final_sp(lv_csid, lv_cursor);
  LOOP
    FETCH lv_cursor INTO lv_studentid, lv_final;
    EXIT WHEN lv_cursor%NOTFOUND;
    DBMS_OUTPUT.PUT_LINE('Student ID: '||lv_studentid||' Final: '||lv_final);
  END LOOP;
END;






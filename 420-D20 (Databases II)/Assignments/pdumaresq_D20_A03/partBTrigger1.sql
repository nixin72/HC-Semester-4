DROP TABLE hvk_change_log;
CREATE TABLE hvk_change_log (userId VARCHAR2(50), changeDate date, notes varchar2(200));

DROP SEQUENCE change_log_seq;
CREATE SEQUENCE change_log_seq 
  START WITH 100
  INCREMENT BY 1;

CREATE OR REPLACE TRIGGER update_change_log
AFTER INSERT OR UPDATE OR DELETE ON hvk_reservation 
FOR EACH ROW
DECLARE
  lv_user VARCHAR(50);
BEGIN 
  SELECT ora_login_user INTO lv_user FROM DUAL; 
    
  INSERT INTO hvk_change_log (
    userId, changeDate, notes
  ) values (
    lv_user, SYSDATE, :new.reservation_number || '/' 
      || :new.reservation_start_date || '/' 
      || :new.reservation_end_date
  );
END;

SET SERVEROUTPUT ON;
DECLARE
  lv_user varchar2(50);
  lv_date date;
  lv_note varchar2(200);
  
  lv_pass number := 0;
BEGIN  
  --insert: Trigger fires after
  INSERT INTO hvk_reservation (
    reservation_number, reservation_start_date, reservation_end_date
  ) values (
    999, to_date('05-Mar-17', 'dd-MM-yy'), to_date('25-Mar-17','dd-MM-yy')
  );
  --Grab the new data from the change log
  SELECT userID, changedate, notes INTO lv_user, lv_date, lv_note
    FROM hvk_change_log
    WHERE Rownum = 1;
  --Check if the data is correct
  IF lv_note != 999 || '/' || to_date('05-Mar-17', 'dd-MM-yy') || '/' || to_date('25-Mar-17','dd-MM-yy') THEN
    DBMS_OUTPUT.PUT_LINE('Test Case 1 failed.');
    DBMS_OUTPUT.PUT_LINE('Expected: ' || 999 || '/' || to_date('05-Mar-17', 'dd-MM-yy') || '/' || to_date('25-Mar-17','dd-MM-yy'));
    DBMS_OUTPUT.PUT_LINE('Received: ' || lv_note);
  ELSE lv_pass := lv_pass + 1;
  END IF; 
  --Wipe the changelog   
  DELETE FROM hvk_change_log;


  --Update the reservation: Changelog will update  fire after it
  UPDATE hvk_reservation
    SET reservation_start_date = to_date('10-Mar-17', 'dd-MM-yy')
  WHERE reservation_number = 999;
  --Grab the new data from the changelog
  SELECT userID, changedate, notes INTO lv_user, lv_date, lv_note
    FROM hvk_change_log
    WHERE Rownum = 1;
  --check if the data is correct
  IF lv_note != 999 || '/' || to_date('10-Mar-17', 'dd-MM-yy') || '/' || to_date('25-Mar-17','dd-MM-yy') THEN
    DBMS_OUTPUT.PUT_LINE('Test Case 2 failed.');
    DBMS_OUTPUT.PUT_LINE('Expected: ' || 999 || '/' || to_date('10-Mar-17', 'dd-MM-yy') || '/' || to_date('25-Mar-17','dd-MM-yy'));
    DBMS_OUTPUT.PUT_LINE('Received: ' || lv_note);
  ELSE lv_pass := lv_pass + 1;
  END IF;
  --Wipe the changelog
  DELETE FROM hvk_change_log;   
    
    
  --Delete: Trigger fires after row is deleted
  DELETE FROM hvk_reservation 
    WHERE reservation_number = 999;
  --Grab the new data from the changelog
  SELECT userID, changedate, notes INTO lv_user, lv_date, lv_note
    FROM hvk_change_log
    WHERE Rownum = 1;
  --check if the data is correct
  IF lv_note != '/' || '/' THEN
    DBMS_OUTPUT.PUT_LINE('Test Case 3 failed.');
    DBMS_OUTPUT.PUT_LINE('Expected: ' || '/' || '/');
    DBMS_OUTPUT.PUT_LINE('Received: ' || lv_note);
  ELSE lv_pass := lv_pass + 1;
  END IF;
  --Wipe the changelog
  DELETE FROM hvk_change_log; 
  
  IF lv_pass = 3 THEN
    DBMS_OUTPUT.PUT_LINE('All test cases passed!');
  ELSE 
    DBMS_OUTPUT.PUT_LINE(lv_pass || '/3 test cases passed.');
  END IF;
END;




Create or replace TRIGGER validate_reservation
BEFORE INSERT OR UPDATE ON hvk_reservation 
FOR EACH ROW
BEGIN 
  IF INSERTING THEN
    IF :new.reservation_start_date <= sysdate THEN
      DBMS_OUTPUT.PUT_LINE('The start date cannot be before today.');
      RAISE_APPLICATION_ERROR(-20001, 'The start date cannot be before today.');
    ELSIF :new.reservation_start_date >= :new.reservation_end_date THEN
      DBMS_OUTPUT.PUT_LINE('The start date cannot be after the end date.');
      RAISE_APPLICATION_ERROR(-20002, 'The start date cannot be after the end date.');
    ELSE 
      DBMS_OUTPUT.PUT_LINE('The reservation was added successfully.');
    END IF;    
  END IF;
  IF UPDATING THEN
    IF :new.reservation_start_date <= sysdate THEN
      DBMS_OUTPUT.PUT_LINE('The start date cannot be before today. The update was canceled.');
      :new.reservation_start_date := :old.reservation_start_date;
    ELSIF :new.reservation_start_date >= :new.reservation_end_date THEN
      DBMS_OUTPUT.PUT_LINE('The start date cannot be after the end date. The update was canceled.');
      :new.reservation_start_date := :old.reservation_start_date;
    ELSE 
      DBMS_OUTPUT.PUT_LINE('The reservation was added successfully.');
    END IF;
  END IF;
END;
/*
  Couldn't find a way to prevent the transaction from occuring entirely without 
  just raising an application error. RAISE_APPLICATION_ERROR ruins the idea of 
  automated test cases, so I was trying to avoid using it, but just couldn't 
  seem to find another way to do it. Would be very interested to know if there 
  is a decent way to cancel a transaction that's about to happen. I tried using 
  customer exceptions, but they just let the insert happen anyways, tried 
  rollback, but the transaction hasn't actually happened yet, etc. Best way I 
  can think of doing it is to create a save point at the before insert, then 
  check the conditions after the insert and chose whether to revert to the save 
  created in the before insert. 
*/


SET SERVEROUTPUT ON;
BEGIN
  --Valid
  INSERT INTO hvk_reservation (
    reservation_number, reservation_start_date, reservation_end_date
  ) values (
    999, to_date('05-Mar-18', 'dd-MM-yy'), to_date('25-Mar-18','dd-MM-yy')
  ); 
  rollback;
  
  --Start date before end date
  UPDATE hvk_reservation 
    SET RESERVATION_END_DATE = to_date('02-Mar-18','dd-MM-yy')
    WHERE RESERVATION_NUMBER = 999;
  
  --Start date before today
  INSERT INTO hvk_reservation (
    reservation_number, reservation_start_date, reservation_end_date
  ) values (
    999, to_date('05-Mar-17', 'dd-MM-yy'), to_date('25-Mar-17','dd-MM-yy')
  );
  
  --Start date after end date
  INSERT INTO hvk_reservation (
    reservation_number, reservation_start_date, reservation_end_date
  ) values (
    999, to_date('25-Mar-18', 'dd-MM-yy'), to_date('05-Mar-18','dd-MM-yy')
  ); 
END;
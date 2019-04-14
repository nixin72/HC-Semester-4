SET SERVEROUTPUT ON;
DECLARE 
  lv_start_date   hvk_reservation.reservation_start_date%TYPE := to_date('&start_date', 'dd-Mon-yy');
  lv_end_date     hvk_reservation.reservation_end_date%TYPE   := to_date('&end_date', 'dd-Mon-yy');
  lv_pet_1        hvk_pet.pet_number%TYPE                     := TO_NUMBER(NVL('&pet_number_1' , 0));
  lv_pet_2        hvk_pet.pet_number%TYPE                     := TO_NUMBER(NVL('&pet_number_2', 0));
  
  lv_owner1       hvk_owner.owner_number%TYPE;
  lv_owner2       hvk_owner.owner_number%TYPE;
  lv_owner_name   VARCHAR2(50);
  
  lv_res_number   hvk_reservation.reservation_number%TYPE;
  lv_pet_res_num1 hvk_pet_reservation.pet_Res_number%TYPE;
  lv_pet_res_num2 hvk_pet_reservation.pet_Res_number%TYPE;
BEGIN
  --ERROR HANDLING
  IF (lv_start_date is null) THEN
    RAISE_APPLICATION_ERROR(-20001, 'Please enter a start date.');
  ELSIF (lv_end_date is null) THEN
    RAISE_APPLICATION_ERROR(-20002, 'Please enter an end date.');
  ELSIF (lv_pet_1 = 0) THEN
    RAISE_APPLICATION_ERROR(-20003, 'Please enter a number for pet 1.');
  ELSIF (lv_pet_2 = 0) THEN
    RAISE_APPLICATION_ERROR(-20004, 'Please enter a number for pet 2.');
  ELSE 
    IF (lv_start_date > lv_end_date) THEN
      RAISE_APPLICATION_ERROR(-20005, 'The start date occurs after the end date.');
    ELSIF (lv_start_date < SYSDATE) THEN
      RAISE_APPLICATION_ERROR(-20006, 'The start date occurs before today.');
    ELSIF (lv_start_date > add_months(SYSDATE, 12)) THEN
      RAISE_APPLICATION_ERROR(-20007, 'The start date must be within 1 year from now.');
    ELSIF (MONTHS_BETWEEN(lv_end_date, lv_start_date) > 6) THEN
      RAISE_APPLICATION_ERROR(-20008, 'The reservation cannot be more than 6 months long.');
    END IF;
    
    IF (lv_pet_1 = lv_pet_2) THEN
      RAISE_APPLICATION_ERROR(-20009, 'Pleas enter two different pet numbers');
    ELSE 
      SELECT p1.own_owner_number, p2.own_owner_number 
        INTO lv_owner1, lv_owner2
      FROM hvk_pet p1, hvk_pet p2
      WHERE p1.pet_number = lv_pet_1
        AND p2.pet_number = lv_pet_2; 
      
      IF lv_owner1 != lv_owner2 THEN
        RAISE_APPLICATION_ERROR(-20010, 'The two pets do not have the same owner.');
      END IF;  
    END IF;  
  END IF;
  
  --Grab the reservatio_number to be used in inserts  
  SELECT hvk_reservation_seq.NEXTVAL INTO lv_res_number
  FROM dual; 
  
  --MAKE INSERT INTO RESERVATION
  INSERT INTO hvk_reservation (
    reservation_number, reservation_start_date, reservation_end_date
  ) VALUES (
    lv_res_number, lv_start_date, lv_end_date
  );  
  
  IF SQL%FOUND THEN
    --find the pet_res_number for pet1
    SELECT hvk_pet_res_seq.NEXTVAL 
      INTO lv_pet_res_num1
      FROM dual;  
      
    --Find the pet_res_number for pet2
    SELECT hvk_pet_res_seq.NEXTVAL 
      INTO lv_pet_res_num2
      FROM dual; 
      
    --INSERT PET 1 INTO PET_RESERVATION TABLE
    INSERT INTO hvk_pet_reservation (
      pet_res_number, pet_pet_number, res_reservation_number, 
      run_run_number, pr_sharing_with
    ) VALUES (
      lv_pet_res_num1, lv_pet_1, lv_res_number,
      null, null
    );
    
    --INSERT PET_RES 1 INTO PET_RESERVATION_SERVICE TABLE
    IF SQL%FOUND THEN
      INSERT INTO hvk_pet_reservation_service (
        SERVICE_FREQUENCY, PR_PET_RES_NUMBER, SERV_SERVICE_NUMBER
      ) VALUES (
        null, lv_pet_res_num1, 1
      );
    END IF; 
    
    --INSERT PET 2 INTO PET_RESERVATION TABLE
    INSERT INTO hvk_pet_reservation (
      pet_res_number, pet_pet_number, res_reservation_number, 
      run_run_number, pr_sharing_with
    ) VALUES (
      lv_pet_res_num2, lv_pet_2, lv_res_number,
      null, lv_pet_res_num1
    ); 
    
    IF SQL%FOUND THEN
      --Update pet_res 1 so that it's sharing with is set properly
      UPDATE hvk_pet_reservation
        SET pr_sharing_with = lv_pet_res_num2
        WHERE pet_res_number = lv_pet_res_num1;
    
      --INSERT PET_RES 2 INTO PET_RESERVATION_SERVICE TABLE
      INSERT INTO hvk_pet_reservation_service (
        service_frequency, pr_pet_res_number, serv_service_number
      ) VALUES (
        null, lv_pet_res_num2, 1
      ); 
      
      --Print out all the data for the reservation added.
      SELECT o.owner_first_name || ' ' || o.owner_last_name into lv_owner_name
        FROM hvk_owner o
        WHERE o.owner_number = lv_owner1;    

      DBMS_OUTPUT.PUT_LINE('Reservation ' || lv_res_number
        || ' has been successfully added for ' || lv_owner_name || '.');
      DBMS_OUTPUT.PUT_LINE('The reservation is from ' || lv_start_date 
        || ' to ' || lv_end_date || '.');
    END IF;
  END IF;
  
  DBMS_OUTPUT.PUT_LINE('');
EXCEPTION
  WHEN no_data_found THEN
    DBMS_OUTPUT.PUT_LINE('One of the pets does not exist');
  WHEN INVALID_NUMBER THEN
    DBMS_OUTPUT.PUT_LINE('Please enter a valid pet number.');
  WHEN VALUE_ERROR THEN
    DBMS_OUTPUT.PUT_LINE('Please enter a valid pet number.');
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('An unknown error occured.');
END;
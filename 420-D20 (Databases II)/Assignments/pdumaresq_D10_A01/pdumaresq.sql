--------------------------------------------------------------------------------
-----------------------------------PART A---------------------------------------
--------------------------------------------------------------------------------
--owner_number
DROP SEQUENCE hvk_owner_seq;
CREATE SEQUENCE hvk_owner_seq 
  Start with 250 increment by 1;
--daily_rate_number
DROP SEQUENCE hvk_daily_rate_seq;
CREATE SEQUENCE hvk_daily_rate_seq 
  Start with 12 increment by 1;
--discount_number
DROP SEQUENCE hvk_discount_seq;
CREATE SEQUENCE hvk_discount_seq 
  Start with 4 increment by 1;
--food_number
DROP SEQUENCE hvk_food_seq;
CREATE SEQUENCE hvk_food_seq 
  Start with 16 increment by 1;
--medication_number  
DROP SEQUENCE hvk_medication_seq;
CREATE SEQUENCE hvk_medication_seq 
  Start with 15 increment by 1;
--pet_res_number  
DROP SEQUENCE hvk_pet_res_seq;
CREATE SEQUENCE hvk_pet_res_seq 
  Start with 2500 increment by 1;
--pet_number 
DROP SEQUENCE hvk_pet_seq;
CREATE SEQUENCE hvk_pet_seq 
  Start with 100 increment by 1;
--reservation_number  
DROP SEQUENCE hvk_reservation_seq;
CREATE SEQUENCE hvk_reservation_seq 
  Start with 2000 increment by 1;
--run_number
DROP SEQUENCE hvk_run_seq;
CREATE SEQUENCE hvk_run_seq 
  Start with 40 increment by 1;
--service_number  
DROP SEQUENCE hvk_service_seq;
CREATE SEQUENCE hvk_service_seq 
  Start with 7 increment by 1;
--vaccination_number 
DROP SEQUENCE hvk_vaccination_seq;
CREATE SEQUENCE hvk_vaccination_seq 
  Start with 7 increment by 1;
--vet_number  
DROP SEQUENCE hvk_vet_seq;
CREATE SEQUENCE hvk_vet_seq 
  Start with 10 increment by 1;
  
--------------------------------------------------------------------------------
-----------------------------------PART B---------------------------------------
--------------------------------------------------------------------------------
SET DEFINE ON;
SET SERVEROUTPUT ON;

DECLARE 
  lv_number     hvk_service.service_number%TYPE := 7;--hvk_service_seq.NEXTVAL;
  lv_desc       hvk_service.service_description%TYPE := '&Service_Description';
  lv_found      NUMBER;
  
  lv_rate_num   hvk_daily_rate.daily_rate_number%TYPE := 13;--hvk_daily_rate_seq.NEXTVAL;
  lv_same_rate  BOOLEAN;
  lv_basic_rate hvk_daily_rate.daily_rate%TYPE;
  lv_increase   NUMBER;
  lv_size		    hvk_daily_rate.daily_rate_dog_size%TYPE;
  
  lv_loop 		  NUMBER := 0;
BEGIN
  lv_desc := UPPER(substr(lv_desc, 0, 1)) || LOWER(substr(lv_desc, 2));
  SELECT count(*) INTO lv_FOUND
    FROM hvk_service 
    WHERE service_description = lv_desc;
  
  IF lv_found = 0 THEN
    lv_same_rate  := 'Y' = UPPER('&Same_rate_for_all_dog_sizes?');
    lv_basic_rate := &Basic_daily_rate;
    lv_increase   := &Increase_between_dog_sizes;
    lv_increase   := (lv_increase/100)+1;
    
    INSERT INTO hvk_service
      ( service_number, service_description ) 
        VALUES ( lv_number, lv_desc );
        
    IF lv_same_rate THEN
      INSERT INTO hvk_daily_rate (
        daily_rate_number, daily_rate, 
        daily_rate_dog_size, serv_service_number
        ) 
        VALUES (
          lv_rate_num, lv_basic_rate, null, lv_number
        );
    ELSE 
      WHILE lv_loop < 3 LOOP
        lv_rate_num := lv_rate_num + 1;
        CASE lv_loop 
           WHEN 0 THEN
            INSERT INTO hvk_daily_rate (
              DAILY_RATE_NUMBER, DAILY_RATE, 
              DAILY_RATE_DOG_SIZE, SERV_SERVICE_NUMBER
            ) VALUES (
              lv_rate_num, lv_basic_rate, 's', lv_number
            );
          WHEN 1 THEN
            INSERT INTO hvk_daily_rate (
              daily_rate_number, daily_rate, 
              daily_rate_dog_size, serv_service_number
            ) VALUES (
              lv_rate_num, lv_basic_rate * lv_increase, 
              'm', lv_number
            );
          WHEN 2 THEN 
            INSERT INTO hvk_daily_rate (
              daily_rate_number, daily_rate, 
              daily_rate_dog_size, serv_service_number
            ) VALUES (
              lv_rate_num, lv_basic_rate * lv_increase * lv_increase, 
              'l', lv_number
            );
        END CASE;
		  END LOOP;
		  DBMS_OUTPUT.PUT_LINE('The service has been added.');  
    END IF;
      
    DBMS_OUTPUT.PUT_LINE(lv_desc);
  ELSE
    DBMS_OUTPUT.PUT_LINE('The service already exists. ' 
      || 'Maybe you want to update the prices?');
  END IF;
  
EXCEPTION
  WHEN DUP_VAL_ON_INDEX THEN
    DBMS_OUTPUT.PUT_LINE('A service with that service number already exisits');
	ROLLBACK;
END;
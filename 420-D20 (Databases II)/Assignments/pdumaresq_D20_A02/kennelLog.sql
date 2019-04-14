SET SERVEROUTPUT ON;
DECLARE
--Test date: 05-Mar-17
  lv_log_date hvk_kennel_log.kennel_log_date%TYPE := to_date('&date', 'dd-Mon-yy');  
  CURSOR lcur_petRes  
    IS SELECT pr.run_run_number, p.pet_name || ' ' || o.owner_last_name AS name, pr.pet_res_number
      FROM hvk_reservation r, hvk_pet_reservation pr, hvk_pet p, hvk_owner o
      WHERE o.owner_number       = p.own_owner_number
        AND p.pet_number         = pr.pet_pet_number
        AND r.reservation_number = pr.res_reservation_number
        AND r.reservation_start_date <= lv_log_date
        AND r.reservation_end_date >= lv_log_date;
        
  CURSOR lcur_food (pv_petRes HVK_PET_RESERVATION.PET_RES_NUMBER%TYPE)
    IS SELECT DISTINCT f.food_brand || ' ' || f.food_variety AS food_name, 
        pf.pet_food_quantity as quantity
      FROM hvk_pet_food pf, hvk_food f, hvk_pet_reservation pr, hvk_reservation r
      WHERE pv_petRes = pf.pr_pet_res_number
        AND pf.food_food_number = f.food_number;
        
  CURSOR lcur_services (pv_petRes HVK_PET_RESERVATION.PET_RES_NUMBER%TYPE)
    IS SELECT DISTINCT s.service_description
      FROM hvk_service s, hvk_pet_reservation_service prs
      WHERE pv_petRes = prs.pr_pet_res_number
        AND prs.serv_service_number = s.service_number;
        
  CURSOR lcur_meds (pv_petRes HVK_PET_RESERVATION.PET_RES_NUMBER%TYPE) 
    IS SELECT DISTINCT m.medication_name, m.medication_dosage, m.medication_special_instruct, 
        m.medication_end_date, m.pr_pet_res_number
      FROM hvk_medication m
      WHERE pv_petRes = m.pr_pet_res_number;
      
  lrec_service lcur_services%ROWTYPE;    
  lrec_med     lcur_meds%ROWTYPE;  
  lv_services  VARCHAR2(100);
  lv_meds      VARCHAR2(100);
BEGIN
  FOR petRes IN lcur_petRes LOOP
    --Run numben, pet name
    DBMS_OUTPUT.PUT_LINE('Run: ' || petRes.run_run_number || ' Pet: ' || petRes.name);
    
    --Food loop
    FOR food IN lcur_food(petRes.pet_res_number) LOOP
      --food name, quantity
      DBMS_OUTPUT.PUT_LINE('Food: ' || food.food_name || ' Quantity: ' || food.quantity);
    END LOOP;
    
    --Loop for servies
    OPEN lcur_services(petRes.pet_res_number);
    FETCH lcur_services INTO lrec_service;
    WHILE lcur_services%FOUND LOOP
      IF lrec_service.service_description != 'Boarding' THEN
        IF lv_services is null THEN 
          lv_services := 'Extra Services: ' || lrec_service.service_description;
        ELSE 
          lv_services := lv_services || ', ' || lrec_service.service_description;
        END IF;
      END IF;
      FETCH lcur_services INTO lrec_service;
    END LOOP;
    CLOSE lcur_services;
    --Print out string built up of services
    DBMS_OUTPUT.PUT_LINE(lv_services);
    lv_services := null;
    
    --Loop for Medication
    OPEN lcur_meds(petRes.pet_res_number);
    LOOP
      FETCH lcur_meds INTO lrec_med;
      EXIT WHEN lcur_meds%NOTFOUND;
      lv_meds := 'Medication: ' || lrec_med.medication_name;
      
      IF lrec_med.medication_dosage is not null THEN
        lv_meds := lv_meds || ' Dosage: ' || lrec_med.medication_dosage;
      END IF;
      
      IF lrec_med.medication_special_instruct is not null THEN
        lv_meds := lv_meds || ' Instructions: ' || lrec_med.medication_special_instruct;
      END IF;
      
      --print out string made up of medication information
      DBMS_OUTPUT.PUT_LINE(lv_meds);
      lv_meds := null;
    END LOOP;
    CLOSE lcur_meds;    
    
    --New Line
    DBMS_OUTPUT.PUT_LINE('');
  END LOOP;
EXCEPTION
  WHEN no_data_found THEN
    DBMS_OUTPUT.PUT_LINE('No data found');
END;
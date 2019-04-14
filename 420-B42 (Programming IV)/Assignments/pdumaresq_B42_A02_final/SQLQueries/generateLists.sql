SET SERVEROUTPUT ON;
/*
--listruns
declare
  cursor runs
  is select * from hvk_run;
begin
  for x in runs loop
    dbms_output.put_line('run.Add(new Run(' || x.run_number || ', ''' 
      || x.run_size || ''', ''' || x.run_covered || ''', ''' 
      || x.run_location || ''', ''' || x.run_status || '));');
  end loop;
end;

--listMeds

/*
declare 
  cursor meds 
  is select medication_number, medication_name, medication_dosage, 
    medication_end_date, pr_pet_res_number
  from hvk_medication;
BEGIN
  for med in meds loop
    dbms_output.put_line('meds.Add(new Medication(' || med.medication_number 
      || ', "' || med.medication_name || '", "' || med.medication_dosage || '", ' 
      || 'DateTime.Parse("' || med.medication_end_date || '").ToString("MM/dd/yyyy"), ' 
      || med.pr_pet_res_number || '));');
  end loop;
END;

--listRates
/*
Declare
  cursor rates 
    is select * from hvk_daily_rate;
BEGIN
  for rate in rates loop
    dbms_output.put_line('rates.Add(new DailyRate(' || rate.daily_rate_number 
      || ', ' || rate.daily_rate || ', ''' || rate.daily_rate_dog_size || ''', ' 
      || rate.serv_service_number || '));');
  end loop;
END;
*/
--listVaccinations

DECLARE 
  cursor vaccs
    IS SELECT v.vaccination_number, v.vaccination_name, pv.vaccination_expiry_date, pv.vaccination_checked_status, p.pet_number
      FROM hvk_pet p, hvk_pet_vaccination pv, hvk_vaccination v
      WHERE p.pet_number               = pv.pet_pet_number
        and pv.vacc_vaccination_number =  v.vaccination_number
        order by p.pet_number;
BEGIN
  FOR vacc in vaccs LOOP
    DBMS_OUTPUT.PUT_LINE('vaccs.Add(new Vaccination(' || vacc.vaccination_number || ', "' 
      || vacc.vaccination_name || '", ' || vacc.pet_number || ', ''' 
      || vacc.vaccination_checked_status || ''' == ''Y''? true : false, ' 
      || 'DateTime.Parse("' || vacc.vaccination_expiry_date || '")));');
  end loop;
end;
/*
--getServices
DECLARE 
  cursor sers 
  IS select s.service_number, s.service_description, prs.pr_pet_res_number, prs.service_frequency
    FROM hvk_service s, hvk_pet_reservation_service prs
    WHERE s.service_number = prs.serv_service_number;
BEGIN
  for ser in sers loop  
    DBMS_OUTPUT.PUT_LINE('servs.Add(new Service(' || ser.service_number 
      || ', "' || ser.service_description || '", ' || ser.pr_pet_res_number 
      || ', ' || nvl(ser.service_frequency, 0) || '));');
  end loop;
END;

--listReservations
*/
DECLARE
  CURSOR lcur_reservations
    IS
      SELECT r.reservation_number, r.reservation_start_date, 
        r.reservation_end_date, p.own_owner_number
      FROM hvk_reservation r, hvk_pet_reservation pr, hvk_pet p
      WHERE r.reservation_number = pr.res_reservation_number
        AND pr.pet_pet_number = p.pet_number
        ORDER BY r.reservation_number;
BEGIN
  for rec in lcur_reservations LOOP
    DBMS_OUTPUT.PUT_LINE('reservations.Add(new Reservation(' 
    || rec.reservation_number || ', ' 
    || 'DateTime.Parse("' || rec.reservation_start_date || '"), ' 
    || 'DateTime.Parse("' || rec.reservation_end_date   || '"), ' 
    || rec.own_owner_number || '));');
  END LOOP;
END;

DECLARE
  CURSOR lcur_pr 
    IS SELECT * FROM hvk_pet_reservation
    ORDER BY pet_res_number;
BEGIN
  FOR x in lcur_pr LOOP
    DBMS_OUTPUT.PUT_LINE('pr.Add(new PetReservation('
      || x.pet_res_number || ', ' || x.pet_pet_number || ', '
      || x.res_reservation_number || ', ' || nvl(x.run_run_number, 0) || ', '
      || nvl(x.pr_sharing_with, 0) || '));');  
  END LOOP;
END;



--testListReservations
SET SERVEROUTPUT ON;
DECLARE
  CURSOR lcur_reservations
    IS
      SELECT DISTINCT r.reservation_number, r.reservation_start_date, 
        r.reservation_end_date, p.own_owner_number
      FROM hvk_reservation r
      LEFT JOIN hvk_pet_reservation pr
        ON pr.RES_RESERVATION_NUMBER = r.RESERVATION_NUMBER
      LEFT JOIN hvk_pet p
        ON p.PET_NUMBER = pr.PET_PET_NUMBER
      ORDER BY r.reservation_number;
  q number := 0;
BEGIN
  for rec in lcur_reservations LOOP
    DBMS_OUTPUT.PUT_LINE('Assert.AreEqual(listReservations[' || q || '].ToString(), new Reservation(' 
    || rec.reservation_number || ', ' 
    || 'DateTime.Parse("' || rec.reservation_start_date || '"), ' 
    || 'DateTime.Parse("' || rec.reservation_end_date   || '"), ' 
    || rec.own_owner_number || ').ToString());');
    
    q := q+1;
  END LOOP;
END;

--testListPetReservations
DECLARE
  CURSOR lcur_pr 
    IS SELECT * FROM hvk_pet_reservation
    ORDER BY pet_res_number;
    q number := 0;
BEGIN
  FOR x in lcur_pr LOOP
    DBMS_OUTPUT.PUT_LINE('Assert.AreEqual(test.listPetReservation()[' || q || '].ToString(), new PetReservation('
      || x.pet_res_number || ', ' || x.pet_pet_number || ', '
      || x.res_reservation_number || ', ' || nvl(x.run_run_number, 0) || ', '
      || nvl(x.pr_sharing_with, 0) || ').ToString());'); 
      
      q := q+1;
  END LOOP;
END;

--testListActiveReservation
Declare 
  CURSOR lcur_all IS 
  SELECT r.reservation_number, o.owner_number, p.pet_number, 
    p.pet_name, run.run_number, r.reservation_start_date, 
    r.reservation_end_date
  FROM hvk_pet p, hvk_pet_reservation pr, hvk_reservation r, hvk_owner o, hvk_run run
    WHERE p.pet_number = pr.pet_pet_number
      AND pr.res_reservation_number = r.reservation_number
      AND o.owner_number = p.own_owner_number
      AND run.run_number = pr.run_run_number
      AND r.reservation_start_date > CURRENT_DATE
      AND r.reservation_end_date < CURRENT_DATE
  union  
  SELECT r.reservation_number, o.owner_number, p.pet_number, 
    p.pet_name, null, r.reservation_start_date, 
    r.reservation_end_date
    FROM hvk_pet p, hvk_pet_reservation pr, hvk_reservation r, hvk_owner o
    WHERE p.pet_number = pr.pet_pet_number
      AND pr.res_reservation_number = r.reservation_number
      AND o.owner_number = p.own_owner_number
      AND pr.run_run_number is null
      AND r.reservation_start_date > CURRENT_DATE
      AND r.reservation_end_date < CURRENT_DATE;
      
  q number := 0;
BEGIN
  DBMS_OUTPUT.PUT_LINE('List<List<String>> list = new List<List<String>>();');
  for res in lcur_all loop
    DBMS_OUTPUT.PUT_LINE('List<String> res' ||q|| ' = new List<String>();' 
      || 'res'||q||'.Add(' || res.reservation_number || '.ToString());'
      || 'res'||q||'.Add(' || res.owner_number || '.ToString());'
      || 'res'||q||'.Add(' || res.pet_number || '.ToString());'
      || 'res'||q||'.Add("' || res.pet_name || '");'
      || 'res'||q||'.Add(' || nvl(res.run_number, 0) || '.ToString());'
      || 'res'||q||'.Add(DateTime.Parse("' || res.reservation_start_date || '").ToString("MM/dd/yyyy"));'
      || 'res'||q||'.Add(DateTime.Parse("' || res.reservation_end_date || '").ToString("MM/dd/yyyy"));'
      || 'list.Add(res'||q||');');
      
    DBMS_OUTPUT.PUT_LINE('Assert.AreEqual(test.listActiveReservations()[' || q || '], list[' || q || ']);');
    
    q := q + 1;
  end loop;
END;


--testListUpcomingReservation
Declare 
  CURSOR lcur_all IS 
  SELECT r.reservation_number, o.owner_number, p.pet_number, 
    p.pet_name, run.run_number, r.reservation_start_date, 
    r.reservation_end_date
  FROM hvk_pet p, hvk_pet_reservation pr, hvk_reservation r, hvk_owner o, hvk_run run
    WHERE p.pet_number = pr.pet_pet_number
      AND pr.res_reservation_number = r.reservation_number
      AND o.owner_number = p.own_owner_number
      AND run.run_number = pr.run_run_number
      AND r.reservation_start_date <= TO_DATE('2-13-2017', 'MM-DD-YYYY')
  union  
  SELECT r.reservation_number, o.owner_number, p.pet_number, 
    p.pet_name, null, r.reservation_start_date, 
    r.reservation_end_date
    FROM hvk_pet p, hvk_pet_reservation pr, hvk_reservation r, hvk_owner o
    WHERE p.pet_number = pr.pet_pet_number
      AND pr.res_reservation_number = r.reservation_number
      AND o.owner_number = p.own_owner_number
      AND pr.run_run_number is null
      AND r.reservation_start_date <= TO_DATE('2-13-2017', 'MM-DD-YYYY')
      ;      
      
  q number := 0;
BEGIN
  DBMS_OUTPUT.PUT_LINE('List<List<String>> list = new List<List<String>>();');
  for res in lcur_all loop
    DBMS_OUTPUT.PUT_LINE('List<String> res' ||q|| ' = new List<String>();' 
      || 'res'||q||'.Add(' || res.reservation_number || '.ToString());'
      || 'res'||q||'.Add(' || res.owner_number || '.ToString());'
      || 'res'||q||'.Add(' || res.pet_number || '.ToString());'
      || 'res'||q||'.Add("' || res.pet_name || '");'
      || 'res'||q||'.Add(' || nvl(res.run_number, 0) || '.ToString());'
      || 'res'||q||'.Add(DateTime.Parse("' || res.reservation_start_date || '").ToString("MM/dd/yyyy"));'
      || 'res'||q||'.Add(DateTime.Parse("' || res.reservation_end_date || '").ToString("MM/dd/yyyy"));'
      || 'list.Add(res'||q||');');
      
    DBMS_OUTPUT.PUT_LINE('Assert.AreEqual(test.listActiveReservations()[' || q || '], list[' || q || ']);');
    
    q := q + 1;
  end loop;
END;*/
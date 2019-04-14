SET SERVEROUTPUT ON;
/*
CREATE OR REPLACE PACKAGE D20_L06_iu_room_pkg IS 
  PROCEDURE room_capacity_pp (
    pv_roomid_i iu_location.roomid%TYPE,
    pv_building_o OUT iu_location.building%TYPE,
    pv_roomid_o   OUT iu_location.roomid%TYPE,
    pv_capacity_o OUT iu_location.capacity%TYPE
  );
  
  PROCEDURE room_capacity_pp (
    pv_roomno_i           iu_location.roomid%TYPE,
    pv_building_i         iu_location.building%TYPE,
    pv_capacity_o   OUT   iu_location.capacity%TYPE
  );
  
  FUNCTION class_capacity_pf (
    pv_csid_i iu_crssection.csid%TYPE
  ) return number;
  
  PROCEDURE test_pkg_sp;
END D20_L06_iu_room_pkg;
*/
CREATE OR REPLACE PACKAGE BODY D20_L06_iu_room_pkg IS
    PROCEDURE room_capacity_pp (
    pv_roomid_i iu_location.roomid%TYPE,
    pv_building_o OUT iu_location.building%TYPE,
    pv_roomid_o   OUT iu_location.roomid%TYPE,
    pv_capacity_o OUT iu_location.capacity%TYPE
  )
  IS 
  BEGIN
    SELECT building, roomid, capacity 
      INTO pv_building_o, pv_roomid_o, pv_capacity_o
      FROM iu_location
      WHERE roomid = pv_roomid_i;  
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      pv_building_o := '';
      pv_roomid_o := 0;
      pv_capacity_o := -1;
  END;
  
  PROCEDURE room_capacity_pp (
    pv_roomno_i           iu_location.roomid%TYPE,
    pv_building_i         iu_location.building%TYPE,
    pv_capacity_o   OUT   iu_location.capacity%TYPE
  ) IS 
  BEGIN
    SELECT capacity INTO pv_capacity_o
      FROM iu_location
      WHERE roomno = pv_roomno_i
        AND building = pv_building_i; 
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      pv_capacity_o := -1;
  END;
  
  FUNCTION class_capacity_pf (
    pv_csid_i iu_crssection.csid%TYPE
  ) return number
  IS 
    lv_retVal number := -1;
  BEGIN
    SELECT l.capacity INTO lv_retVal
      FROM iu_location l, iu_crssection c
      WHERE c.csid   = pv_csid_i
        AND c.roomid = l.roomid; 
    return lv_retVal;
  EXCEPTION
    WHEN NO_DATA_FOUND THEN
      return -1;
  END;
  
  PROCEDURE test_pkg_sp IS 
BEGIN
  DECLARE
    lv_building iu_location.building%TYPE;
    lv_roomid   iu_location.roomid%TYPE;
    lv_capacity iu_location.capacity%TYPE; 
    lv_csid iu_crssection.csid%TYPE;
    
    lv_success number := 0;
  BEGIN
--Test room_capacity_pp(roomid)
    room_capacity_pp(19, lv_building, lv_roomid, lv_capacity);
    lv_success := CASE 
      WHEN lv_building = 'Kennedy' AND lv_roomid = 19 AND lv_capacity = 30 
        THEN lv_success + 1
      ELSE lv_success END;
    DBMS_OUTPUT.PUT_LINE('Building - Expected value: Kennedy / Actual value: ' || lv_building );
    DBMS_OUTPUT.PUT_LINE('Room Id  - Expected value: 19 / Actual value: ' || lv_roomid );
    DBMS_OUTPUT.PUT_LINE('Capacity - Expected value: 30 / Actual value: ' || lv_capacity );
    
    room_capacity_pp(55, lv_building, lv_roomid, lv_capacity);
    lv_success := CASE 
    WHEN lv_building IS NULL and lv_roomid = 0 and lv_capacity = -1 
      THEN lv_success + 1
    ELSE lv_success END;
    DBMS_OUTPUT.PUT_LINE('Building - Expected value: -- / Actual value: ' || lv_building );
    DBMS_OUTPUT.PUT_LINE('Room Id  - Expected value: -- / Actual value: ' || lv_roomid );
    DBMS_OUTPUT.PUT_LINE('Capacity - Expected value: -1 / Actual value: ' || lv_capacity );    
        
--Test room_capacity_pp(roomid, building)    
DBMS_OUTPUT.PUT_LINE('');
    room_capacity_pp(210, 'Kennedy', lv_capacity);
    lv_success := CASE WHEN lv_capacity = 30 THEN lv_success + 1 ELSE lv_success END;
    DBMS_OUTPUT.PUT_LINE('Capacity - Expected value: 30 / Actual value: ' || lv_capacity);
    
    room_capacity_pp(101, 'Jasper', lv_capacity);
    lv_success := CASE WHEN lv_capacity = -1 THEN lv_success + 1 ELSE lv_success END;
    DBMS_OUTPUT.PUT_LINE('Capacity - Expected value: -1 / Actual value: ' || lv_capacity);    
        
--Test class_capacity_pf(csid)  
    DBMS_OUTPUT.PUT_LINE('');
    lv_csid := class_capacity_pf(1209);
    lv_success := CASE WHEN lv_csid = 40 THEN lv_success + 1 ELSE lv_success END;
    DBMS_OUTPUT.PUT_LINE('Maxcount - Expected value: 40 / Actual value: ' || lv_csid);
    
    lv_csid := class_capacity_pf(1415);
    lv_success := CASE WHEN lv_csid = -1 THEN lv_success + 1 ELSE lv_success END;
    DBMS_OUTPUT.PUT_LINE('Maxcount - Expected value: -1 / Actual value: ' || lv_csid);
    
--End result
    DBMS_OUTPUT.PUT_LINE('');
    DBMS_OUTPUT.PUT_LINE('Succeeded: ' || lv_success);
    DBMS_OUTPUT.PUT_LINE('% Passed: ' || (lv_success / 6) * 100);
    DBMS_OUTPUT.PUT_LINE('% Failed: ' || ((6-lv_success) / 6) * 100);
  END;
END;
END D20_L06_iu_room_pkg;

BEGIN
  D20_L06_IU_ROOM_PKG.TEST_PKG_SP;
END;



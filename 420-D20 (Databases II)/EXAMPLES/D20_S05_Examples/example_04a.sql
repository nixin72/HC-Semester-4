---
--- Exercise 2 solution
---  Show the building, office number and phone number of each member of the 
---  faculty.
---  Simple demonstraton of a cursor for loop with
---- a) explicitly defined cursor
---  b) implicitly defined record from cursor
---
--- 


DECLARE
   lv_building    iu_location.building%TYPE;
   lv_roomno      iu_location.roomno%TYPE;
 
   CURSOR lcur_faculty
   IS
      SELECT *
        FROM iu_faculty;
BEGIN
   FOR lrec_faculty IN lcur_faculty
   LOOP
-- Get the office building and room number
      SELECT building, roomno
        INTO lv_building, lv_roomno
        FROM iu_location
       WHERE roomid = lrec_faculty.roomid;
 
-- Display the result
      DBMS_OUTPUT.put_line (   'Name: '
                            || lrec_faculty.NAME
                            || ' Building: '
                            || lv_building
                            || ' Office Number: '
                            || lv_roomno
                            || ' Phone Number: '
                            || lrec_faculty.phone
                           );
   END LOOP;
END;

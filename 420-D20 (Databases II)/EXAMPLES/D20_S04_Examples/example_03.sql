---
--- Exercise: Write a program that reads and displays the building,
---  office and phone number for faculty member Rivera.
--- Note: 
--- 1) faculty record is a row of the iu_faculty table
--- 2) use of record field in the second select
--- 

DECLARE
   lrec_faculty   iu_faculty%ROWTYPE;
   lv_building    iu_LOCATION.building%TYPE;
   lv_roomno      iu_LOCATION.roomno%TYPE;
BEGIN
-- Get the faculty record for Rivera
   SELECT *
     INTO lrec_faculty
     FROM iu_faculty
    WHERE UPPER (NAME) = 'RIVERA';

-- Get the office building and room number for Rivera
   SELECT building, roomno
     INTO lv_building, lv_roomno
     FROM iu_LOCATION
    WHERE roomid = lrec_faculty.roomid;

-- Display the result
   DBMS_OUTPUT.put_line (   'Building: '
                         || lv_building
                         || ' Office Number: '
                         || lv_roomno
                         || ' Phone Number: '
                         || lrec_faculty.phone
                        );
END;

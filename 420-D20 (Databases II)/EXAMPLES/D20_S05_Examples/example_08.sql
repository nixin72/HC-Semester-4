---
--- Exercise 4:
---  Add a term for ‘WN17’, ‘Winter 2017’, starts Jan 19, 2017, ends June 1, 2017
---  Using a cursor, loop through IU_CRSSECTION and for every row from termId ‘WN15’, insert a row for WN17.
---  You will need to assign unique csid, start from 4600
DECLARE
   lv_csid   iu_crssection.csid%TYPE   := 4600;

   --- loop through all the Winter 2015 course sections
   CURSOR lcur_crssection
   IS
      SELECT courseid, section, maxcount
        FROM iu_crssection
       WHERE termid = 'WN15';
BEGIN
-- Add the Winter 2017 term
   INSERT INTO iu_term
        VALUES ('WN17', 'Winter 2017', to_date('19-JAN-17','DD-MON-RR'),
        to_date('11-JUN-17','DD-MON-RR'));

   FOR lrec_sectiondata IN lcur_crssection
   LOOP
-- Add all the course sections from the Winter 2015 term to Crssection
-- for the Winter 2017 Term
-- avoid updateing the rooms, times and faculty for now to keep it simple
      INSERT INTO iu_crssection
                  (csid, courseid, section,
                   termid, maxcount
                  )
           VALUES (lv_csid, lrec_sectiondata.courseid,
                   lrec_sectiondata.section,
                   'WN17', lrec_sectiondata.maxcount
                  );

      lv_csid := lv_csid + 1;
   END LOOP;

  --- COMMIT; Rollback after you're convinced your code works.
END;
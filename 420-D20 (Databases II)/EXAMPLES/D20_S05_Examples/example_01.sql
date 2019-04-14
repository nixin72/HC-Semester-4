---
--- List the relationship and birth date for each of Sunny Chen's dependents. 
--- Demonstrate:
--- 1) basic "for" loop
--- 2) if/then/else
--- 3) oracle side join (boo!  change to ansi join)
---
--- note the use of END IF; END LOOP; there are no {} to delineate
--- 
SET serveroutput ON
DECLARE
   lv_employeeid         nn_employee.employeeid%TYPE;
   lv_relation           nn_dependent.relation%TYPE;
   lv_dob                nn_dependent.depdob%TYPE;
   lv_count_dependents   NUMBER;
BEGIN
-- get number of dependents for Sunny Chen
   SELECT   e.employeeid, COUNT (dependentid)
       INTO lv_employeeid, lv_count_dependents
       FROM nn_employee e, nn_dependent d
      WHERE UPPER (e.lname) = 'CHEN'
        AND UPPER (e.fname) = 'SUNNY'
        AND e.employeeid = d.employeeid (+)
   GROUP BY e.employeeid;

-- if there are no dependents display a message
   IF lv_count_dependents = 0
   THEN
      DBMS_OUTPUT.put_line ('Sunny Chen has no dependents.');
   ELSE
      DBMS_OUTPUT.put_line ('Sunny Chen''s dependents are: ');

      FOR lv_counter IN 1 .. lv_count_dependents
-- read the data for each of Sunny Chen's dependents
      LOOP
-- get the dependent information for each dependent
         SELECT relation, depdob
           INTO lv_relation, lv_dob
           FROM nn_dependent
          WHERE employeeid = lv_employeeid
            AND dependentid = TRIM (TO_CHAR (lv_counter, '09'));

-- display the results
         DBMS_OUTPUT.put_line (   '   Relation: '
                               || lv_relation
                               || ' Birth date: '
                               || lv_dob
                              );
      END LOOP;
   END IF;
END;

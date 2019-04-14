DECLARE
   lv_creditsearned   iu_student.creditsearned%TYPE;
BEGIN
-- Test case 1
   UPDATE iu_registration
      SET FINAL = 'B'
    WHERE studentid = '00100' AND csid = 1207;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 9
   THEN
      DBMS_OUTPUT.put_line ('Test case 1 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 1 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   ROLLBACK;

--
-- Test case 2
--
   UPDATE iu_registration
      SET FINAL = 'A'
    WHERE studentid = '00100' AND csid = 1101;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 9
   THEN
      DBMS_OUTPUT.put_line ('Test case 2 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 2 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   ROLLBACK;

--
-- Test case 3
--
   UPDATE iu_registration
      SET FINAL = 'C'
    WHERE studentid = '00103' AND csid = 1101;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00103';

   IF lv_creditsearned = 6
   THEN
      DBMS_OUTPUT.put_line ('Test case 3 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 3 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   ROLLBACK;

--
-- Test case 4
--
   UPDATE iu_registration
      SET FINAL = 'F'
    WHERE studentid = '00100' AND csid = 1205;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 6
   THEN
      DBMS_OUTPUT.put_line ('Test case 4 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 4 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   ROLLBACK;

--
-- Test case 5
--
   UPDATE iu_registration
      SET FINAL = 'F'
    WHERE studentid = '00100' AND csid = 1102;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 3
   THEN
      DBMS_OUTPUT.put_line ('Test case 5 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 5 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   ROLLBACK;

--
-- Test case 6
--
   UPDATE iu_registration
      SET FINAL = 'F'
    WHERE studentid = '00103' AND csid = 1101;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00103';

   IF lv_creditsearned = 3
   THEN
      DBMS_OUTPUT.put_line ('Test case 6 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 6 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   ROLLBACK;

--
-- Test case 7
--
   UPDATE iu_registration
      SET FINAL = 'B'
    WHERE studentid = '00100' AND csid = 1104;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 6
   THEN
      DBMS_OUTPUT.put_line ('Test case 7 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 7 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   ROLLBACK;
--
-- Test case 8
--
   update IU_REGISTRATION
      SET FINAL = null
    WHERE studentid = '00100' AND csid = 1104;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 3
   THEN
      DBMS_OUTPUT.put_line ('Test case 8 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 8 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   rollback;

--
-- Test case 9
--
   DELETE iu_registration
      WHERE studentid = '00100' AND csid = 1101;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 6
   THEN
      DBMS_OUTPUT.put_line ('Test case 9 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 9 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   ROLLBACK;

--
-- Test case 10
--
   DELETE      iu_registration
         WHERE studentid = '00100' AND csid = 1104;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 3
   THEN
      DBMS_OUTPUT.put_line ('Test case 10 successful');
   ELSE
      DBMS_OUTPUT.put_line
                    (   '!!!!!!!!!!!!! Test case 10 failed. creditsearned is '
                     || lv_creditsearned
                     || ' !!!!!!!!!!!!! '
                    );
   END IF;

   ROLLBACK;
--
-- Test case 11
--
   DELETE      iu_registration
         WHERE studentid = '00103' AND csid = 1101;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00103';

   IF lv_creditsearned = 3
   THEN
      DBMS_OUTPUT.put_line ('Test case 11 successful');
   ELSE
      DBMS_OUTPUT.put_line
                   (   '!!!!!!!!!!!!! Test case 11 failed. creditsearned is '
                    || lv_creditsearned
                    || ' !!!!!!!!!!!!! '
                   );
   END IF;

   ROLLBACK;

--

--
-- Test case 12
--
   DELETE      iu_registration
         WHERE studentid = '00100' AND csid = 1205;

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 6
   THEN
      DBMS_OUTPUT.put_line ('Test case 12 successful');
   ELSE
      DBMS_OUTPUT.put_line
                   (   '!!!!!!!!!!!!! Test case 12 failed. creditsearned is '
                    || lv_creditsearned
                    || ' !!!!!!!!!!!!! '
                   );
   END IF;

   ROLLBACK;

--
-- Test case 13
--
   INSERT INTO iu_registration
               (studentid, csid
               )
        VALUES ('00100', 1206
               );

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 6
   THEN
      DBMS_OUTPUT.put_line ('Test case 13 successful');
   ELSE
      DBMS_OUTPUT.put_line
                   (   '!!!!!!!!!!!!! Test case 13 failed. creditsearned is '
                    || lv_creditsearned
                    || ' !!!!!!!!!!!!! '
                   );
   END IF;

   ROLLBACK;

--
-- Test case 14
--
   INSERT INTO iu_registration
               (studentid, csid, FINAL
               )
        VALUES ('00100', 1103, 'B'
               );

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 9
   THEN
      DBMS_OUTPUT.put_line ('Test case 14 successful');
   ELSE
      DBMS_OUTPUT.put_line
                   (   '!!!!!!!!!!!!! Test case 14 failed. creditsearned is '
                    || lv_creditsearned
                    || ' !!!!!!!!!!!!! '
                   );
   END IF;

   ROLLBACK;



--
-- Test case 15
--
   INSERT INTO iu_registration
               (studentid, csid, FINAL
               )
        VALUES ('00100', 1103, 'F'
               );

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 6
   THEN
      DBMS_OUTPUT.put_line ('Test case 15 successful');
   ELSE
      DBMS_OUTPUT.put_line
                   (   '!!!!!!!!!!!!! Test case 15 failed. creditsearned is '
                    || lv_creditsearned
                    || ' !!!!!!!!!!!!! '
                   );
   END IF;

   ROLLBACK;

--
-- Test case 16
--
   INSERT INTO iu_registration
               (studentid, csid, FINAL
               )
        VALUES ('00100', 1103, 'W'
               );

   SELECT creditsearned
     INTO lv_creditsearned
     FROM iu_student
    WHERE studentid = '00100';

   IF lv_creditsearned = 6
   THEN
      DBMS_OUTPUT.put_line ('Test case 16 successful');
   ELSE
      DBMS_OUTPUT.put_line
                   (   '!!!!!!!!!!!!! Test case 16 failed. creditsearned is '
                    || lv_creditsearned
                    || ' !!!!!!!!!!!!! '
                   );
   END IF;

   ROLLBACK;
END;
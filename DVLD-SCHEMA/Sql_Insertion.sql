INSERT INTO LicenseClasses
(ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
VALUES
('Class 1 - Small Motorcycle',
 'Small motorcycles up to 125cc',
 18, 5, 15.00),

('Class 2 - Heavy Motorcycle',
 'Motorcycles above 125cc',
 21, 5, 20.00),

('Class 3 - Private Car',
 'Regular passenger vehicles',
 18, 10, 25.00),

('Class 4 - Commercial',
 'Light commercial vehicles',
 21, 10, 30.00),

('Class 5 - Agricultural',
 'Agricultural and farming vehicles',
 21, 10, 30.00),

('Class 6 - Small & Medium Bus',
 'Small and medium passenger buses',
 24, 10, 40.00),

('Class 7 - Heavy Truck',
 'Heavy trucks and large transport vehicles',
 24, 10, 50.00);



 INSERT INTO TestTypes
(TestTypeTitle, TestTypeFees, TestTypeDescription)
VALUES
('Vision Test',
 10.00,
 'Eye examination including visual acuity and color blindness'),

('Written Test',
 20.00,
 'Traffic rules, road signs, and driving regulations test'),

('Street Test',
 30.00,
 'Practical driving test conducted on public roads');



 INSERT INTO ApplicationTypes
(ApplicationTypeTitle, ApplicationTypeFees)
VALUES
('New Driving License Service', 15.00),
('Renew Driving License Service', 10.00),
('Replacement for Lost Driving License', 20.00),
('Replacement for Damaged Driving License', 5.00),
('Release Detained Driving License', 20.00),
('New International Driving License', 50.00);

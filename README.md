# Platform Developer Assessment

The solution has implemented the following changes:

1. Changing the method signature of CustomerService
2. Splitting the CustomerRepository into write and read responsibilities.
3. Using a Json file based storage to emulate a portable and persistent database.
4. Added reactive Add, Delete and Edit buttons depending on the customer dropdown value
5. Validations on the Customer form for various inputs.
6. An assumption is made that the customer data and contact data fields are not related and can contain different values.
7. Unit tests to test the CustomerService behavior.

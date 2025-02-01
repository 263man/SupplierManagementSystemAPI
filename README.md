# SupplierManagementSystemAPI
Developer Document for Supplier Management System API

System Purpose
This API facilitates stock requests between users (pharmacies, doctors, and other companies) and suppliers. It supports multiple platforms, including WPF-based ATA Pharmacy, a WPF supplier dashboard, and external integrations via API keys. The first phase focuses on medical use cases, allowing suppliers to manage inventory and users to request stock efficiently.

Key Features
User Authentication and Authorization
Secure login for doctors, pharmacies, and external companies.
Role-based access ensures each user type has specific capabilities.
Supplier Management
Suppliers are registered and approved by Stream Solutions.
Suppliers manage inventory, approve requests, and dispatch items via a WPF dashboard.
Request Source Tracking
Tracks the software or platform initiating stock requests (e.g., ATA Pharmacy, Web App).
Each source is uniquely identified by an API key (e.g., ATAPHARM) and contact details.
Stock Management
Suppliers manage stock categorized by product type.
Users view supplier-specific inventory and submit requests based on available items.
Connection Management
Users search for suppliers and send connection requests.
Suppliers approve or reject connections to control who can place orders.
Request Workflow
Users submit stock requests to connected suppliers.
Requests are logged with a unique request number, item-level details, and an overall order status.
Stock is deducted upon request approval.
Automated Supplier Matching
Matches suppliers to users based on criteria such as location and stock categories.
Audit and Monitoring
Logs all significant actions, such as status updates and item approvals, for full traceability.
Notification System
Sends email notifications to users for each status change in the request lifecycle (e.g., Pending, Awaiting Payment, Approved, Dispatched).

Workflow
Step
Description
Supplier Registration
Suppliers register via the Supplier Approval Portal. Stream Solutions reviews and approves them.
User-Supplier Connection
Users search for suppliers and send connection requests. Suppliers approve or reject connections.
Stock Management
Suppliers categorize and update their stock. Users browse inventory and submit requests.
Request Submission
Users select items and submit a stock request. A unique request number is generated.
Request Approval
Suppliers approve or reject requested items. Approved quantities are deducted from inventory.
Notifications
Email notifications are sent for each status change (e.g., Pending, Awaiting Payment, Approved).
Dispatch
Once items are dispatched, the status updates to Dispatched, and users are notified.


Database Tables
1. tblUsers
Column Name
Data Type
Description
UserID
INT (PK)
Unique user identifier
Username
NVARCHAR(50)
User login name
PasswordHash
VARBINARY(MAX)
Hashed password
Role
NVARCHAR(20)
Role of the user (Pharmacy, Doctor, etc.)
DateCreated
DATETIME
Date of account creation

2. tblSuppliers
Column Name
Data Type
Description
SupplierID
INT (PK)
Unique supplier identifier
Name
NVARCHAR(100)
Supplier name
CityID
INT (FK)
Reference to tblCity
Status
NVARCHAR(20)
Supplier approval status

3. tblCategory
Column Name
Data Type
Description
CategoryID
INT (PK)
Unique category identifier
CategoryName
NVARCHAR(50)
Category name (e.g., Medicine)
Description
NVARCHAR(200)
Optional description of the category
DateAdded
DATETIME
Date of category creation

4. tblStock
Column Name
Data Type
Description
StockID
INT (PK)
Unique stock identifier
SupplierID
INT (FK)
Reference to tblSuppliers
ItemName
NVARCHAR(100)
Name of the stock item
CategoryID
INT (FK)
Reference to tblCategory
Quantity
INT
Available stock quantity
UnitPrice
DECIMAL(10, 2)
Price per unit
DateAdded
DATETIME
Date stock item was added

5. tblRequestSources
Column Name
Data Type
Description
RequestSourceID
INT (PK)
Unique request source identifier
SourceName
NVARCHAR(100)
Name of the source (e.g., ATA Pharmacy)
UniqueCode
NVARCHAR(20)
API key for identifying the source
ContactPerson
NVARCHAR(100)
Name of the contact person
ContactEmail
NVARCHAR(100)
Contact email address
ContactPhone
NVARCHAR(20)
Contact phone number
CompanyName
NVARCHAR(100)
Development company's name
Address
NVARCHAR(200)
Company address
DateAdded
DATETIME
Date the source was added

6. tblRequestDetails
Column Name
Data Type
Description
RequestDetailID
INT (PK)
Unique request detail identifier
RequestNumber
NVARCHAR(50)
Unique request number
UserID
INT (FK)
Reference to tblUsers
SupplierID
INT (FK)
Reference to tblSuppliers
RequestSourceID
INT (FK)
Reference to tblRequestSources
RequestDate
DATETIME
Date of the request
Status
NVARCHAR(20)
Request status (e.g., Pending, Awaiting Payment, Approved, Dispatched)

7. tblStockRequests
Column Name
Data Type
Description
StockRequestID
INT (PK)
Unique stock request identifier
RequestDetailID
INT (FK)
Reference to tblRequestDetails
StockID
INT (FK)
Reference to tblStock
QuantityRequested
INT
Quantity requested
QuantityApproved
INT (Nullable)
Quantity approved by supplier
Status
NVARCHAR(20)
Item status (e.g., Pending, Approved, Rejected)


8. tblEmailNotifications
Column Name
Data Type
Description
EmailID
INT (PK)
Unique email identifier
RequestDetailID
INT (FK)
Reference to tblRequestDetails
Status
NVARCHAR(20)
Status at the time of email
EmailSentDate
DATETIME
Date the email was sent
RecipientEmail
NVARCHAR(100)
User's email address




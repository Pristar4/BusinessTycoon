```mermaid
graph LR
A(Start Game) --> B(Update UI)
B --> C(Handle User Input)
C --> D(Update Game State)
D --> E(Calculate Financials)
D --> F(Execute Marketing Campaigns)
D --> G(Manage Products)
D --> H(Manage Employees)
D --> I(Run Simulation)
E --> J(Monitor Cash Balance)
E --> K(Track Revenue)
E --> L(Monitor Expenses)
E --> M(Make Financial Decisions)
F --> N(Select Marketing Channels)
F --> O(Set Budgets)
F --> P(Monitor Campaign Performance)
G --> Q(Develop Product)
G --> R(Set Prices)
G --> S(Allocate Resources)
H --> T(View Available Employees)
H --> U(Assign Roles)
H --> V(Monitor Employee Morale)
H --> W(Invest In Training)
J --> D
K --> D
L --> D
M --> D
N --> F
O --> F
P --> F
Q --> G
R --> G
S --> G
T --> H
U --> H
V --> H
W --> H
I --> D
D --> X{End Game?}
X -->|No| B
X -->|Yes| Y(End Game)

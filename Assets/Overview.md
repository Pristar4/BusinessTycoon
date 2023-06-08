


# Game Flow:

```mermaid
graph LR
Start[Start] --> MakeDecisions[Make Decisions]
MakeDecisions --> ProgressTime[Progress Time]
ProgressTime --> EndGame{End Game?}
EndGame -- No --> MakeDecisions
EndGame -- Yes --> GameOver(Game Over)
```
# Manage Products:

```mermaid
graph LR
Start --> ManageProducts[Manage Products]
ManageProducts --> ResearchDev[Research & Development]
ManageProducts --> SetPrices[Set Prices]
ManageProducts --> AllocateResources[Allocate Resources]
```

# Plan Marketing:

```mermaid
graph LR
Start --> PlanMarketing[Plan Marketing]
PlanMarketing --> SelectChannels[Select Marketing Channels]
PlanMarketing --> SetBudgets[Set Budgets]
PlanMarketing --> MonitorPerformance[Monitor Campaign Performance]
```
# Handle Finances:

```mermaid

graph LR
Start --> HandleFinances[Handle Finances]
HandleFinances --> MonitorCash[Monitor Cash Balance]
HandleFinances --> TrackRevenue[Track Revenue]
HandleFinances --> MonitorExpenses[Monitor Expenses]
```
# Hire Employees:

```mermaid
graph LR
Start --> HireEmployees[Hire Employees]
HireEmployees --> ViewEmployees[View Available Employees]
HireEmployees --> AssignRoles[Assign Roles]
HireEmployees --> MonitorMorale[Monitor Employee Morale]
HireEmployees --> InvestTraining[Invest in Training]
```
# Product Flow:

```mermaid
graph LR
ManageProducts --> ProductFlow
ProductFlow --> DevelopProduct[Develop Product]
DevelopProduct --> LaunchProduct[Launch Product]
LaunchProduct --> MonitorSales[Monitor Sales]
MonitorSales --> CollectFeedback[Collect Feedback]
```
These separate graphs represent the individual aspects of the game, including the game flow, managing products, planning marketing, handling finances, hiring employees, and the flow of a product from development to feedback collection.

You can refer to each graph to understand the specific logic and flow of that aspect in more detail.

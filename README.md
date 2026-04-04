# Bug Colony

3D simulation of a bug colony. Bugs move, collect resources, reproduce, and mutate.

## Features

- Top-down 3D simulation with simple primitives (boxes, spheres, capsules).  
- **Worker Bugs**: collect resources, reproduce, possible mutation to predators.  
- **Predator Bugs**: attack and eat bugs and resources, reproduce after eating.  
- Automatic respawn if colony dies.  
- UI displays dead bug counters (workers & predators).  

## Architecture

- **Clean-ish / Hybrid Clean Architecture**: clear layer separation, each layer has single responsibility.  
- **Extensible & Flexible**: easy to add new bug types or behaviors.  
- **Patterns Used**: Strategy, Factory, Object Pool, Dependency Injection (Zenject).  

## Tools & Frameworks

- Unity 6000.0.67f1
- C#  
- Zenject (DI)  
- uGUI for UI  

## Code Highlights

- Focus on readability, maintainability, and layer responsibility.  
- Bug behaviors encapsulated via **Strategy** pattern.  
- Spawning handled via **Factory** and pooled for efficiency.  
- DI ensures decoupled, testable code.  

## Getting Started

Clone the repository:  
```bash
git clone https://github.com/mdpromotion/Bug-Colony.git

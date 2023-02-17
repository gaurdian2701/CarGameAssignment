This is the Assignment for the Vyorius Test.
This Scene was created entirely using ready-made assets from the asset store.
Assets used:
1. ARCADE - FREE RACING CAR asset from the Unity Asset Store:
![image](https://user-images.githubusercontent.com/55644010/219655340-e41f32c3-eac5-4318-82e4-c1ad245cb007.png)

2. Modular Track Kit Asset from the Unity's built-in Kart-Racing game Template available from Unity Hub project Setup.



**IMPLEMENTATION:**
- The following track was made using Unity's Modular Track Kit Asset:
![image](https://user-images.githubusercontent.com/55644010/219676348-56fada16-faba-4ec5-aa9b-2b124ff570e4.png)
- An additional track has also been made:
![image](https://user-images.githubusercontent.com/55644010/219676640-33f1368e-2186-4abc-ab86-1878e5ee1286.png)


- Movement was implemented using Unity's new Input System
- The following is a screenshot of the input action asset used for the scene:
![image](https://user-images.githubusercontent.com/55644010/219665137-e4eb2c69-6979-40d6-98fa-cd8dfaa12ffd.png)
- Since this is a simple car simulation, a single action map for the car is used.
- The **Up, Down, Left, Right arrow keys** are used for the movement of the car.
- A separate key for braking is used. This is because it is simpler to use two different keys to implement reversing and braking.
- Using the same key for braking and reversing would rely on the in-built wheel collider's **motor torque** which does not give a solid stopping effect. Therefore, a      separate key, **spacebar**, is used to brake the car, and the down arrow key is used to reverse the car. The spacebar key makes use of the **brake torque** of the   wheel colliders which is more reliable.
- The actual controls are applied to the wheel colliders, which are then relayed to the actual game objects in the scene by changing the position and rotation of the wheel visuals/wheel transforms(wheel gameobjects) with respect to the wheel colliders.
- Wheel Colliders moving without updating Wheel Visuals:
![image](https://user-images.githubusercontent.com/55644010/219667120-677c299c-3683-4283-97d6-b57377a4ee08.png)
- Wheel Colliders moving while updating Wheel Visuals:
![image](https://user-images.githubusercontent.com/55644010/219667375-a565a431-1387-4575-bb8b-ddddfd738a57.png)

![image](https://user-images.githubusercontent.com/55644010/219668037-c0ab4323-cc0b-4b8f-ab4d-fcecd27e5654.png)
- Above are the wheel collider properties.
- The above values apply to all four of the wheels of the car. The Suspension spring value is set to as high as 60000(indicating strong spring action) in order to avoid toppling during sudden turns at high speeds and turning while braking.
- The damper value is set to the standard value 4500 to provide a slight bounce action to the car.
- The forward and sideways friction values are left as they are to avoid unnecessary skidding during turns.



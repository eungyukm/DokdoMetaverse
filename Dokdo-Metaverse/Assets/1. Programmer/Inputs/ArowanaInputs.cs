// GENERATED AUTOMATICALLY FROM 'Assets/1. Programmer/Inputs/ArowanaInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ArowanaInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ArowanaInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ArowanaInputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""f62a4b92-ef5e-4175-8f4c-c9075429d32c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6bc1aaf4-b110-4ff7-891e-5b9fe6f32c4d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""2690c379-f54d-45be-a724-414123833eb4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8c4abdf8-4099-493a-aa1a-129acec7c3df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""PassThrough"",
                    ""id"": ""980e881e-182c-404c-8cbf-3d09fdb48fef"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraPosition"",
                    ""type"": ""Value"",
                    ""id"": ""d4d60889-ae9b-41ec-baf8-aa28688836bd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""b7594ddb-26c9-4ba2-bd5a-901468929edc"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2063a8b5-6a45-43de-851b-65f3d46e7b58"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""64e4d037-32e1-4fb9-80e4-fc7330404dfe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0fce8b11-5eab-4e4e-a741-b732e7b20873"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7bdda0d6-57a8-47c8-8238-8aecf3110e47"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bb94b405-58d3-4998-8535-d705c1218a98"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""929d9071-7dd0-4368-9743-6793bb98087e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""28abadba-06ff-4d37-bb70-af2f1e35a3b9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""45f115b6-9b4f-4ba8-b500-b94c93bf7d7e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e2f9aa65-db06-4c5b-a2e9-41bc8acb9517"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed66cbff-2900-4a62-8896-696503cfcd31"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),ScaleVector2(x=15,y=15)"",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1d171b6-19d8-47a6-ba3a-71b6a8e7b3c0"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),StickDeadzone,ScaleVector2(x=300,y=300)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bd55a0b-761e-4ae4-89ae-8ec127e08a29"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f973413-5e27-4239-acee-38c4a63feeba"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc65b89f-9bd3-43fb-92af-d0d87ba5faa4"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8fcd86e-dcfd-4f88-8e93-b638cdbf3320"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b0c3ec0-28fd-4221-9f08-4b5491228170"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""CameraPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""id"": ""5e4a5d1c-14f2-4cf3-84aa-7d53bfca4992"",
            ""actions"": [
                {
                    ""name"": ""PrimaryTouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5e3be9d7-8491-45a7-b00c-d2b413f768b9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.7,pressPoint=0.5)""
                },
                {
                    ""name"": ""PrimaryTouchDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d93fbe27-31a3-4bef-b20a-3d944c55768f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.7,pressPoint=0.5)""
                },
                {
                    ""name"": ""SecondaryTouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""726d2c37-db47-4b0a-82d2-24f9d646ef19"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.7,pressPoint=0.5)""
                },
                {
                    ""name"": ""SecondaryTouchDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""56eba2b6-030c-44cc-879f-e5a6a2b03229"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.7,pressPoint=0.5)""
                },
                {
                    ""name"": ""Double Tap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7c8a9ab1-8e92-4081-a9bb-ff696ffbc365"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap(tapTime=0.6,tapDelay=0.8,pressPoint=0.9)""
                },
                {
                    ""name"": ""Hold"",
                    ""type"": ""PassThrough"",
                    ""id"": ""aa85dbbc-1f4c-4fb3-9e8e-676315f83304"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Slow Tap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4157ee00-f077-4248-ab14-281f11114e15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""SlowTap""
                },
                {
                    ""name"": ""Press"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b77748cd-a8ab-4671-a593-396ea83926fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Release"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1e9fcd5b-496e-4664-8ebd-1b66ad902cbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Single Tap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f68f4249-8309-4ff0-9415-6ada23542061"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""77096b91-f0cc-4339-ac70-1609044363aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a778bd1d-7758-4dba-b6c1-1e5cad76bbf3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b5bc6058-15ec-4304-82c9-8d248c3a2259"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5a2c8d70-b318-40b2-8fd3-3dea29e2ecfc"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0370251-0f09-4fa5-8921-f08d1bccba02"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d7ce26d-217f-48b3-8588-191bbffa4050"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""defcac0f-fd07-4a19-9c4a-7808842731cc"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69d8ca22-c530-4320-a0e3-52ff69f92aa2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cab59317-2f39-4fbb-b424-958aca74a8d3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Double Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d4de3fa-a3a6-4f3e-81e8-013ed8445519"",
                    ""path"": ""<Touchscreen>/touch0/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Double Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed62bfe2-6500-44f0-8150-a2a502338281"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7068f00-f89a-4bbe-9248-bde616dd9e5d"",
                    ""path"": ""<Touchscreen>/touch0/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f97ee5bf-4bae-4458-a83c-ef8e4fd29545"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Slow Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cecc763-4a3c-4455-929f-8c7a1fa37617"",
                    ""path"": ""<Touchscreen>/touch0/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Slow Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e943e91a-3afd-4884-9db4-57970534c523"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abe079c1-f7d7-40b9-b183-b89c61067d6b"",
                    ""path"": ""<Touchscreen>/touch0/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d500838-2e0a-48b3-9dfc-b3dc689fabea"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e74f0f8-d549-48ae-af5a-aa997b1d55f5"",
                    ""path"": ""<Touchscreen>/touch0/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""700f41de-53d1-42d9-a32a-02e1d5959e2e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Single Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7443202e-6615-4719-b3d1-d50dda9d7974"",
                    ""path"": ""<Touchscreen>/touch0/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Single Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d186877-e7f0-4a9f-839f-53e726f97ed7"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f55060cd-d508-4c64-b2d7-e11095e58617"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""753f1c33-032a-48a8-a23b-96327b527ad9"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7c97e24-7fa7-4ce4-8e91-57fdf4af0ae8"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f70c725b-66e5-4db2-b488-8cf218afd31a"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f7b1dd6-acca-4720-ac9b-821c2b59460f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8408c448-bccb-41b0-8530-374d7b74a7ec"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c48f6fe-a7ed-44b8-9139-572489176e33"",
                    ""path"": ""<Touchscreen>/touch0/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19fd94fc-0fab-4e2b-a1f6-1012b3b3ff4f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf900cc5-014e-476c-859c-cb7b09d0884d"",
                    ""path"": ""<Touchscreen>/touch1/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouchDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Xbox Controller"",
            ""bindingGroup"": ""Xbox Controller"",
            ""devices"": []
        },
        {
            ""name"": ""PS4 Controller"",
            ""bindingGroup"": ""PS4 Controller"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_CameraPosition = m_Player.FindAction("CameraPosition", throwIfNotFound: true);
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_PrimaryTouch = m_Touch.FindAction("PrimaryTouch", throwIfNotFound: true);
        m_Touch_PrimaryTouchDelta = m_Touch.FindAction("PrimaryTouchDelta", throwIfNotFound: true);
        m_Touch_SecondaryTouch = m_Touch.FindAction("SecondaryTouch", throwIfNotFound: true);
        m_Touch_SecondaryTouchDelta = m_Touch.FindAction("SecondaryTouchDelta", throwIfNotFound: true);
        m_Touch_DoubleTap = m_Touch.FindAction("Double Tap", throwIfNotFound: true);
        m_Touch_Hold = m_Touch.FindAction("Hold", throwIfNotFound: true);
        m_Touch_SlowTap = m_Touch.FindAction("Slow Tap", throwIfNotFound: true);
        m_Touch_Press = m_Touch.FindAction("Press", throwIfNotFound: true);
        m_Touch_Release = m_Touch.FindAction("Release", throwIfNotFound: true);
        m_Touch_SingleTap = m_Touch.FindAction("Single Tap", throwIfNotFound: true);
        m_Touch_Click = m_Touch.FindAction("Click", throwIfNotFound: true);
        m_Touch_RightClick = m_Touch.FindAction("Right Click", throwIfNotFound: true);
        m_Touch_Point = m_Touch.FindAction("Point", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_CameraPosition;
    public struct PlayerActions
    {
        private @ArowanaInputs m_Wrapper;
        public PlayerActions(@ArowanaInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @CameraPosition => m_Wrapper.m_Player_CameraPosition;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @CameraPosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraPosition;
                @CameraPosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraPosition;
                @CameraPosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraPosition;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @CameraPosition.started += instance.OnCameraPosition;
                @CameraPosition.performed += instance.OnCameraPosition;
                @CameraPosition.canceled += instance.OnCameraPosition;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_PrimaryTouch;
    private readonly InputAction m_Touch_PrimaryTouchDelta;
    private readonly InputAction m_Touch_SecondaryTouch;
    private readonly InputAction m_Touch_SecondaryTouchDelta;
    private readonly InputAction m_Touch_DoubleTap;
    private readonly InputAction m_Touch_Hold;
    private readonly InputAction m_Touch_SlowTap;
    private readonly InputAction m_Touch_Press;
    private readonly InputAction m_Touch_Release;
    private readonly InputAction m_Touch_SingleTap;
    private readonly InputAction m_Touch_Click;
    private readonly InputAction m_Touch_RightClick;
    private readonly InputAction m_Touch_Point;
    public struct TouchActions
    {
        private @ArowanaInputs m_Wrapper;
        public TouchActions(@ArowanaInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryTouch => m_Wrapper.m_Touch_PrimaryTouch;
        public InputAction @PrimaryTouchDelta => m_Wrapper.m_Touch_PrimaryTouchDelta;
        public InputAction @SecondaryTouch => m_Wrapper.m_Touch_SecondaryTouch;
        public InputAction @SecondaryTouchDelta => m_Wrapper.m_Touch_SecondaryTouchDelta;
        public InputAction @DoubleTap => m_Wrapper.m_Touch_DoubleTap;
        public InputAction @Hold => m_Wrapper.m_Touch_Hold;
        public InputAction @SlowTap => m_Wrapper.m_Touch_SlowTap;
        public InputAction @Press => m_Wrapper.m_Touch_Press;
        public InputAction @Release => m_Wrapper.m_Touch_Release;
        public InputAction @SingleTap => m_Wrapper.m_Touch_SingleTap;
        public InputAction @Click => m_Wrapper.m_Touch_Click;
        public InputAction @RightClick => m_Wrapper.m_Touch_RightClick;
        public InputAction @Point => m_Wrapper.m_Touch_Point;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @PrimaryTouch.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouchDelta.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryTouchDelta;
                @PrimaryTouchDelta.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryTouchDelta;
                @PrimaryTouchDelta.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryTouchDelta;
                @SecondaryTouch.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryTouch;
                @SecondaryTouch.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryTouch;
                @SecondaryTouch.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryTouch;
                @SecondaryTouchDelta.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryTouchDelta;
                @SecondaryTouchDelta.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryTouchDelta;
                @SecondaryTouchDelta.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondaryTouchDelta;
                @DoubleTap.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnDoubleTap;
                @DoubleTap.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnDoubleTap;
                @DoubleTap.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnDoubleTap;
                @Hold.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnHold;
                @Hold.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnHold;
                @Hold.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnHold;
                @SlowTap.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSlowTap;
                @SlowTap.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSlowTap;
                @SlowTap.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSlowTap;
                @Press.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPress;
                @Press.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPress;
                @Press.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPress;
                @Release.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnRelease;
                @Release.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnRelease;
                @Release.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnRelease;
                @SingleTap.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSingleTap;
                @SingleTap.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSingleTap;
                @SingleTap.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSingleTap;
                @Click.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnClick;
                @RightClick.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnRightClick;
                @Point.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPoint;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryTouch.started += instance.OnPrimaryTouch;
                @PrimaryTouch.performed += instance.OnPrimaryTouch;
                @PrimaryTouch.canceled += instance.OnPrimaryTouch;
                @PrimaryTouchDelta.started += instance.OnPrimaryTouchDelta;
                @PrimaryTouchDelta.performed += instance.OnPrimaryTouchDelta;
                @PrimaryTouchDelta.canceled += instance.OnPrimaryTouchDelta;
                @SecondaryTouch.started += instance.OnSecondaryTouch;
                @SecondaryTouch.performed += instance.OnSecondaryTouch;
                @SecondaryTouch.canceled += instance.OnSecondaryTouch;
                @SecondaryTouchDelta.started += instance.OnSecondaryTouchDelta;
                @SecondaryTouchDelta.performed += instance.OnSecondaryTouchDelta;
                @SecondaryTouchDelta.canceled += instance.OnSecondaryTouchDelta;
                @DoubleTap.started += instance.OnDoubleTap;
                @DoubleTap.performed += instance.OnDoubleTap;
                @DoubleTap.canceled += instance.OnDoubleTap;
                @Hold.started += instance.OnHold;
                @Hold.performed += instance.OnHold;
                @Hold.canceled += instance.OnHold;
                @SlowTap.started += instance.OnSlowTap;
                @SlowTap.performed += instance.OnSlowTap;
                @SlowTap.canceled += instance.OnSlowTap;
                @Press.started += instance.OnPress;
                @Press.performed += instance.OnPress;
                @Press.canceled += instance.OnPress;
                @Release.started += instance.OnRelease;
                @Release.performed += instance.OnRelease;
                @Release.canceled += instance.OnRelease;
                @SingleTap.started += instance.OnSingleTap;
                @SingleTap.performed += instance.OnSingleTap;
                @SingleTap.canceled += instance.OnSingleTap;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    private int m_PS4ControllerSchemeIndex = -1;
    public InputControlScheme PS4ControllerScheme
    {
        get
        {
            if (m_PS4ControllerSchemeIndex == -1) m_PS4ControllerSchemeIndex = asset.FindControlSchemeIndex("PS4 Controller");
            return asset.controlSchemes[m_PS4ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCameraPosition(InputAction.CallbackContext context);
    }
    public interface ITouchActions
    {
        void OnPrimaryTouch(InputAction.CallbackContext context);
        void OnPrimaryTouchDelta(InputAction.CallbackContext context);
        void OnSecondaryTouch(InputAction.CallbackContext context);
        void OnSecondaryTouchDelta(InputAction.CallbackContext context);
        void OnDoubleTap(InputAction.CallbackContext context);
        void OnHold(InputAction.CallbackContext context);
        void OnSlowTap(InputAction.CallbackContext context);
        void OnPress(InputAction.CallbackContext context);
        void OnRelease(InputAction.CallbackContext context);
        void OnSingleTap(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
    }
}

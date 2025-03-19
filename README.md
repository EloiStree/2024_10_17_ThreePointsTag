# 2024_10_17_ThreePointsTag

This tool has a single purpose: to tag a 3D object with three points, which can then be used across various utilities, packages, and tools to load and recalibrate the object in the 3D world.

You don't want a heavy package that updates every 6 months cluttering your project. However, you still need to tag a set of three points on objects for the purpose of loading and calibrating them.

To address this, I’ve separated my tool, **ThreePointsAction**, into three distinct components:

- **ThreePointTag**:  
  Allows you to tag objects, prefabs, scenes, and meshes with a 3-point interface, enabling them to be loaded when needed.

- **ThreePointsLoader**:  
  Utilizes the ThreePointTag to load scenes, prefabs, and actions based on the three given points.

- **ThreePointsMeshBuilder**:  
  Enables you to build meshes that can be exported from tagged triangles using a finger or XR controller.

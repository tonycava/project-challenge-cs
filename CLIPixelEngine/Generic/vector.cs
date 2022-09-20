namespace CLIPixelEngine.Engine.Generic {
    public class Vector2Int {
        public int x {get;set;}
        public int y {get;set;}
        public Vector2Int(int x = 0,int y = 0) {
            this.x = x;
            this.y = y;
        }
    };

    public class Vector2 {
        public float x {get;set;}
        public float y {get;set;}
        public Vector2(float x=0,float y=0) {
            this.x = x;
            this.y = y;
        }
    };

    public class Vector3Int {
        public int x {get;set;}
        public int y {get;set;}
        public int z {get;set;}
        public Vector3Int(int x=0,int y=0,int z=0) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    };

    public class Vector3 {
        public float x {get;set;}
        public float y {get;set;}
        public float z {get;set;}
        public Vector3(float x=0,float y=0,float z=0) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    };
}
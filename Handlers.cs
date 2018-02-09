namespace Common.Handler
{
    public class Handlers
    {
        public delegate void SimpleHandler(object sender);
        public delegate void VoidHandler();
        public delegate void IntHandler(int param);
        public delegate void ObjHandler(int type, object[] param);
        public delegate void ParamHandler(object[] param);
    }
}

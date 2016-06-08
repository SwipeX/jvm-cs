namespace jvm_cs.core.member
{
    public class InnerClassData : MemberData
    {
        public string InnerInfo { get; }
        public string OuterInfo { get; }

        public InnerClassData(string name, int access, string inner, string outer) : base(name, access)
        {
            InnerInfo = inner;
            OuterInfo = outer;
        }

        public bool IsAnonymous() => Name.Equals("");
    }
}
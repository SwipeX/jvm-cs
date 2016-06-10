using jvm_cs.core.member;

namespace jvm_cs.core.attribute
{
    public class Attribute
    {
        private string _name;
        private uint _length;
        public dynamic Owner { get; } //TODO Problem with dynamic is that calls are not verified by compiler, and this is not a good solution.
        //Either it should be handled on a case to case basis, or there should be some elegant way to combat this issue.

        public Attribute(string name, uint length, MemberData owner)
        {
            _name = name;
            _length = length;
            Owner = owner;
        }

        public virtual void ReadBytes(DataReader reader)
        {
            reader.ReadBytes((int) _length);
        }

        public string Name()
        {
            return _name;
        }
    }
}
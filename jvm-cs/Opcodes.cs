using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvm_cs
{
    public class Opcodes
    {
        public const int FIELD = 9;

        /**
         * The type of CONSTANT_Methodref constant pool items.
         */
        public const int METH = 10;

        /**
         * The type of CONSTANT_InterfaceMethodref constant pool items.
         */
        public const int IMETH = 11;

        /**
         * The type of CONSTANT_String constant pool items.
         */
        public const int STR = 8;

        /**
         * The type of CONSTANT_Integer constant pool items.
         */
        public const int INT = 3;

        /**
         * The type of CONSTANT_Float constant pool items.
         */
        public const int FLOAT = 4;

        /**
         * The type of CONSTANT_Long constant pool items.
         */
        public const int LONG = 5;

        /**
         * The type of CONSTANT_Double constant pool items.
         */
        public const int DOUBLE = 6;

        /**
         * The type of CONSTANT_NameAndType constant pool items.
         */
        public const int NAME_TYPE = 12;

        /**
         * The type of CONSTANT_Utf8 constant pool items.
         */
        public const int UTF8 = 1;

        /**
         * The type of CONSTANT_MethodType constant pool items.
         */
        public const int MTYPE = 16;

        /**
         * The type of CONSTANT_MethodHandle constant pool items.
         */
        public const int HANDLE = 15;

        /**
         * The type of CONSTANT_InvokeDynamic constant pool items.
         */
        public const int INDY = 18;

        public const int CLASS = 7;

        public const int INVOKE_DYNAMIC = 18;
        // versions

        private int V1_1 = 3 << 16 | 45;
        private int V1_2 = 0 << 16 | 46;
        private int V1_3 = 0 << 16 | 47;
        private int V1_4 = 0 << 16 | 48;
        private int V1_5 = 0 << 16 | 49;
        private int V1_6 = 0 << 16 | 50;
        private int V1_7 = 0 << 16 | 51;
        private int V1_8 = 0 << 16 | 52;

        // access flags

        private int ACC_PUBLIC = 0x0001; // class, field, method
        private int ACC_PRIVATE = 0x0002; // class, field, method
        private int ACC_PROTECTED = 0x0004; // class, field, method
        private int ACC_const = 0x0008; // field, method
        private int ACC_FINAL = 0x0010; // class, field, method, parameter
        private int ACC_SUPER = 0x0020; // class
        private int ACC_SYNCHRONIZED = 0x0020; // method
        private int ACC_VOLATILE = 0x0040; // field
        private int ACC_BRIDGE = 0x0040; // method
        private int ACC_VARARGS = 0x0080; // method
        private int ACC_TRANSIENT = 0x0080; // field
        private int ACC_NATIVE = 0x0100; // method
        private int ACC_INTERFACE = 0x0200; // class
        private int ACC_ABSTRACT = 0x0400; // class, method
        private int ACC_STRICT = 0x0800; // method
        private int ACC_SYNTHETIC = 0x1000; // class, field, method, parameter
        private int ACC_ANNOTATION = 0x2000; // class
        private int ACC_ENUM = 0x4000; // class(?) field inner
        private int ACC_MANDATED = 0x8000; // parameter

        // ASM specific pseudo access flags

        private int ACC_DEPRECATED = 0x20000; // class, field, method

        // types for NEWARRAY

        private int T_BOOLEAN = 4;
        private int T_CHAR = 5;
        private int T_FLOAT = 6;
        private int T_DOUBLE = 7;
        private int T_BYTE = 8;
        private int T_SHORT = 9;
        private int T_INT = 10;
        private int T_LONG = 11;

        // tags for Handle

        private int H_GETFIELD = 1;
        private int H_GETconst = 2;
        private int H_PUTFIELD = 3;
        private int H_PUTconst = 4;
        private int H_INVOKEVIRTUAL = 5;
        private int H_INVOKEconst = 6;
        private int H_INVOKESPECIAL = 7;
        private int H_NEWINVOKESPECIAL = 8;
        private int H_INVOKEINTERFACE = 9;

        // stack map frame types

        /**
         * Represents an expanded frame. See {@link ClassReader#EXPAND_FRAMES}.
         */
        private int F_NEW = -1;

        /**
         * Represents a compressed frame with complete frame data.
         */
        private int F_FULL = 0;

        /**
         * Represents a compressed frame where locals are the same as the locals in
         * the previous frame, except that additional 1-3 locals are defined, and
         * with an empty stack.
         */
        private int F_APPEND = 1;

        /**
         * Represents a compressed frame where locals are the same as the locals in
         * the previous frame, except that the last 1-3 locals are absent and with
         * an empty stack.
         */
        private int F_CHOP = 2;

        /**
         * Represents a compressed frame with exactly the same locals as the
         * previous frame and with an empty stack.
         */
        private int F_SAME = 3;

        /**
         * Represents a compressed frame with exactly the same locals as the
         * previous frame and with a single value on the stack.
         */
        private int F_SAME1 = 4;

        // opcodes // visit method (- = idem)

        private int NOP = 0; // visitInsn
        private int ACONST_NULL = 1; // -
        private int ICONST_M1 = 2; // -
        private int ICONST_0 = 3; // -
        private int ICONST_1 = 4; // -
        private int ICONST_2 = 5; // -
        private int ICONST_3 = 6; // -
        private int ICONST_4 = 7; // -
        private int ICONST_5 = 8; // -
        private int LCONST_0 = 9; // -
        private int LCONST_1 = 10; // -
        private int FCONST_0 = 11; // -
        private int FCONST_1 = 12; // -
        private int FCONST_2 = 13; // -
        private int DCONST_0 = 14; // -
        private int DCONST_1 = 15; // -
        private int BIPUSH = 16; // visitIntInsn
        private int SIPUSH = 17; // -
        private int LDC = 18; // visitLdcInsn

        // int LDC_W = 19; // -
        // int LDC2_W = 20; // -
        private int ILOAD = 21; // visitVarInsn

        private int LLOAD = 22; // -
        private int FLOAD = 23; // -
        private int DLOAD = 24; // -
        private int ALOAD = 25; // -

        // int ILOAD_0 = 26; // -
        // int ILOAD_1 = 27; // -
        // int ILOAD_2 = 28; // -
        // int ILOAD_3 = 29; // -
        // int LLOAD_0 = 30; // -
        // int LLOAD_1 = 31; // -
        // int LLOAD_2 = 32; // -
        // int LLOAD_3 = 33; // -
        // int FLOAD_0 = 34; // -
        // int FLOAD_1 = 35; // -
        // int FLOAD_2 = 36; // -
        // int FLOAD_3 = 37; // -
        // int DLOAD_0 = 38; // -
        // int DLOAD_1 = 39; // -
        // int DLOAD_2 = 40; // -
        // int DLOAD_3 = 41; // -
        // int ALOAD_0 = 42; // -
        // int ALOAD_1 = 43; // -
        // int ALOAD_2 = 44; // -
        // int ALOAD_3 = 45; // -
        private int IALOAD = 46; // visitInsn

        private int LALOAD = 47; // -
        private int FALOAD = 48; // -
        private int DALOAD = 49; // -
        private int AALOAD = 50; // -
        private int BALOAD = 51; // -
        private int CALOAD = 52; // -
        private int SALOAD = 53; // -
        private int ISTORE = 54; // visitVarInsn
        private int LSTORE = 55; // -
        private int FSTORE = 56; // -
        private int DSTORE = 57; // -
        private int ASTORE = 58; // -

        // int ISTORE_0 = 59; // -
        // int ISTORE_1 = 60; // -
        // int ISTORE_2 = 61; // -
        // int ISTORE_3 = 62; // -
        // int LSTORE_0 = 63; // -
        // int LSTORE_1 = 64; // -
        // int LSTORE_2 = 65; // -
        // int LSTORE_3 = 66; // -
        // int FSTORE_0 = 67; // -
        // int FSTORE_1 = 68; // -
        // int FSTORE_2 = 69; // -
        // int FSTORE_3 = 70; // -
        // int DSTORE_0 = 71; // -
        // int DSTORE_1 = 72; // -
        // int DSTORE_2 = 73; // -
        // int DSTORE_3 = 74; // -
        // int ASTORE_0 = 75; // -
        // int ASTORE_1 = 76; // -
        // int ASTORE_2 = 77; // -
        // int ASTORE_3 = 78; // -
        private int IASTORE = 79; // visitInsn

        private int LASTORE = 80; // -
        private int FASTORE = 81; // -
        private int DASTORE = 82; // -
        private int AASTORE = 83; // -
        private int BASTORE = 84; // -
        private int CASTORE = 85; // -
        private int SASTORE = 86; // -
        private int POP = 87; // -
        private int POP2 = 88; // -
        private int DUP = 89; // -
        private int DUP_X1 = 90; // -
        private int DUP_X2 = 91; // -
        private int DUP2 = 92; // -
        private int DUP2_X1 = 93; // -
        private int DUP2_X2 = 94; // -
        private int SWAP = 95; // -
        private int IADD = 96; // -
        private int LADD = 97; // -
        private int FADD = 98; // -
        private int DADD = 99; // -
        private int ISUB = 100; // -
        private int LSUB = 101; // -
        private int FSUB = 102; // -
        private int DSUB = 103; // -
        private int IMUL = 104; // -
        private int LMUL = 105; // -
        private int FMUL = 106; // -
        private int DMUL = 107; // -
        private int IDIV = 108; // -
        private int LDIV = 109; // -
        private int FDIV = 110; // -
        private int DDIV = 111; // -
        private int IREM = 112; // -
        private int LREM = 113; // -
        private int FREM = 114; // -
        private int DREM = 115; // -
        private int INEG = 116; // -
        private int LNEG = 117; // -
        private int FNEG = 118; // -
        private int DNEG = 119; // -
        private int ISHL = 120; // -
        private int LSHL = 121; // -
        private int ISHR = 122; // -
        private int LSHR = 123; // -
        private int IUSHR = 124; // -
        private int LUSHR = 125; // -
        private int IAND = 126; // -
        private int LAND = 127; // -
        private int IOR = 128; // -
        private int LOR = 129; // -
        private int IXOR = 130; // -
        private int LXOR = 131; // -
        private int IINC = 132; // visitIincInsn
        private int I2L = 133; // visitInsn
        private int I2F = 134; // -
        private int I2D = 135; // -
        private int L2I = 136; // -
        private int L2F = 137; // -
        private int L2D = 138; // -
        private int F2I = 139; // -
        private int F2L = 140; // -
        private int F2D = 141; // -
        private int D2I = 142; // -
        private int D2L = 143; // -
        private int D2F = 144; // -
        private int I2B = 145; // -
        private int I2C = 146; // -
        private int I2S = 147; // -
        private int LCMP = 148; // -
        private int FCMPL = 149; // -
        private int FCMPG = 150; // -
        private int DCMPL = 151; // -
        private int DCMPG = 152; // -
        private int IFEQ = 153; // visitJumpInsn
        private int IFNE = 154; // -
        private int IFLT = 155; // -
        private int IFGE = 156; // -
        private int IFGT = 157; // -
        private int IFLE = 158; // -
        private int IF_ICMPEQ = 159; // -
        private int IF_ICMPNE = 160; // -
        private int IF_ICMPLT = 161; // -
        private int IF_ICMPGE = 162; // -
        private int IF_ICMPGT = 163; // -
        private int IF_ICMPLE = 164; // -
        private int IF_ACMPEQ = 165; // -
        private int IF_ACMPNE = 166; // -
        private int GOTO = 167; // -
        private int JSR = 168; // -
        private int RET = 169; // visitVarInsn
        private int TABLESWITCH = 170; // visiTableSwitchInsn
        private int LOOKUPSWITCH = 171; // visitLookupSwitch
        private int IRETURN = 172; // visitInsn
        private int LRETURN = 173; // -
        private int FRETURN = 174; // -
        private int DRETURN = 175; // -
        private int ARETURN = 176; // -
        private int RETURN = 177; // -
        private int GETconst = 178; // visitFieldInsn
        private int PUTconst = 179; // -
        private int GETFIELD = 180; // -
        private int PUTFIELD = 181; // -
        private int INVOKEVIRTUAL = 182; // visitMethodInsn
        private int INVOKESPECIAL = 183; // -
        private int INVOKEconst = 184; // -
        private int INVOKEINTERFACE = 185; // -
        private int INVOKEDYNAMIC = 186; // visitInvokeDynamicInsn
        private int NEW = 187; // visitTypeInsn
        private int NEWARRAY = 188; // visitIntInsn
        private int ANEWARRAY = 189; // visitTypeInsn
        private int ARRAYLENGTH = 190; // visitInsn
        private int ATHROW = 191; // -
        private int CHECKCAST = 192; // visitTypeInsn
        private int INSTANCEOF = 193; // -
        private int MONITORENTER = 194; // visitInsn
        private int MONITOREXIT = 195; // -

        // int WIDE = 196; // NOT VISITED
        private int MULTIANEWARRAY = 197; // visitMultiANewArrayInsn

        private int IFNULL = 198; // visitJumpInsn
        private int IFNONNULL = 199; // -
        // int GOTO_W = 200; // -
        // int JSR_W = 201; // -
    }
}
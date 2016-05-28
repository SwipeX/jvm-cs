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

        public static int V1_1 = 3 << 16 | 45;
        public static int V1_2 = 0 << 16 | 46;
        public static int V1_3 = 0 << 16 | 47;
        public static int V1_4 = 0 << 16 | 48;
        public static int V1_5 = 0 << 16 | 49;
        public static int V1_6 = 0 << 16 | 50;
        public static int V1_7 = 0 << 16 | 51;
        public static int V1_8 = 0 << 16 | 52;

        // Access flags

        public static int ACC_PUBLIC = 0x0001; // class, field, method
        public static int ACC_STATIC = 0x0002; // class, field, method
        public static int ACC_PROTECTED = 0x0004; // class, field, method
        public static int ACC_const = 0x0008; // field, method
        public static int ACC_FINAL = 0x0010; // class, field, method, parameter
        public static int ACC_SUPER = 0x0020; // class
        public static int ACC_SYNCHRONIZED = 0x0020; // method
        public static int ACC_VOLATILE = 0x0040; // field
        public static int ACC_BRIDGE = 0x0040; // method
        public static int ACC_VARARGS = 0x0080; // method
        public static int ACC_TRANSIENT = 0x0080; // field
        public static int ACC_NATIVE = 0x0100; // method
        public static int ACC_INTERFACE = 0x0200; // class
        public static int ACC_ABSTRACT = 0x0400; // class, method
        public static int ACC_STRICT = 0x0800; // method
        public static int ACC_SYNTHETIC = 0x1000; // class, field, method, parameter
        public static int ACC_ANNOTATION = 0x2000; // class
        public static int ACC_ENUM = 0x4000; // class(?) field inner
        public static int ACC_MANDATED = 0x8000; // parameter

        // ASM specific pseudo Access flags

        public static int ACC_DEPRECATED = 0x20000; // class, field, method

        // types for NEWARRAY

        public static int T_BOOLEAN = 4;
        public static int T_CHAR = 5;
        public static int T_FLOAT = 6;
        public static int T_DOUBLE = 7;
        public static int T_BYTE = 8;
        public static int T_SHORT = 9;
        public static int T_INT = 10;
        public static int T_LONG = 11;

        // tags for Handle

        public static int H_GETFIELD = 1;
        public static int H_GETconst = 2;
        public static int H_PUTFIELD = 3;
        public static int H_PUTconst = 4;
        public static int H_INVOKEVIRTUAL = 5;
        public static int H_INVOKEconst = 6;
        public static int H_INVOKESPECIAL = 7;
        public static int H_NEWINVOKESPECIAL = 8;
        public static int H_INVOKEINTERFACE = 9;

        // stack map frame types

        /**
         * Represents an expanded frame. See {@link ClassReader#EXPAND_FRAMES}.
         */
        public static int F_NEW = -1;

        /**
         * Represents a compressed frame with complete frame data.
         */
        public static int F_FULL = 0;

        /**
         * Represents a compressed frame where locals are the same as the locals in
         * the previous frame, except that additional 1-3 locals are defined, and
         * with an empty stack.
         */
        public static int F_APPEND = 1;

        /**
         * Represents a compressed frame where locals are the same as the locals in
         * the previous frame, except that the last 1-3 locals are absent and with
         * an empty stack.
         */
        public static int F_CHOP = 2;

        /**
         * Represents a compressed frame with exactly the same locals as the
         * previous frame and with an empty stack.
         */
        public static int F_SAME = 3;

        /**
         * Represents a compressed frame with exactly the same locals as the
         * previous frame and with a single value on the stack.
         */
        public static int F_SAME1 = 4;

        // opcodes // visit method (- = idem)

        public static int NOP = 0; // visitInsn
        public static int ACONST_NULL = 1; // -
        public static int ICONST_M1 = 2; // -
        public static int ICONST_0 = 3; // -
        public static int ICONST_1 = 4; // -
        public static int ICONST_2 = 5; // -
        public static int ICONST_3 = 6; // -
        public static int ICONST_4 = 7; // -
        public static int ICONST_5 = 8; // -
        public static int LCONST_0 = 9; // -
        public static int LCONST_1 = 10; // -
        public static int FCONST_0 = 11; // -
        public static int FCONST_1 = 12; // -
        public static int FCONST_2 = 13; // -
        public static int DCONST_0 = 14; // -
        public static int DCONST_1 = 15; // -
        public static int BIPUSH = 16; // visitIntInsn
        public static int SIPUSH = 17; // -
        public static int LDC = 18; // visitLdcInsn

        // int LDC_W = 19; // -
        // int LDC2_W = 20; // -
        public static int ILOAD = 21; // visitVarInsn

        public static int LLOAD = 22; // -
        public static int FLOAD = 23; // -
        public static int DLOAD = 24; // -
        public static int ALOAD = 25; // -

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
        public static int IALOAD = 46; // visitInsn

        public static int LALOAD = 47; // -
        public static int FALOAD = 48; // -
        public static int DALOAD = 49; // -
        public static int AALOAD = 50; // -
        public static int BALOAD = 51; // -
        public static int CALOAD = 52; // -
        public static int SALOAD = 53; // -
        public static int ISTORE = 54; // visitVarInsn
        public static int LSTORE = 55; // -
        public static int FSTORE = 56; // -
        public static int DSTORE = 57; // -
        public static int ASTORE = 58; // -

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
        public static int IASTORE = 79; // visitInsn

        public static int LASTORE = 80; // -
        public static int FASTORE = 81; // -
        public static int DASTORE = 82; // -
        public static int AASTORE = 83; // -
        public static int BASTORE = 84; // -
        public static int CASTORE = 85; // -
        public static int SASTORE = 86; // -
        public static int POP = 87; // -
        public static int POP2 = 88; // -
        public static int DUP = 89; // -
        public static int DUP_X1 = 90; // -
        public static int DUP_X2 = 91; // -
        public static int DUP2 = 92; // -
        public static int DUP2_X1 = 93; // -
        public static int DUP2_X2 = 94; // -
        public static int SWAP = 95; // -
        public static int IADD = 96; // -
        public static int LADD = 97; // -
        public static int FADD = 98; // -
        public static int DADD = 99; // -
        public static int ISUB = 100; // -
        public static int LSUB = 101; // -
        public static int FSUB = 102; // -
        public static int DSUB = 103; // -
        public static int IMUL = 104; // -
        public static int LMUL = 105; // -
        public static int FMUL = 106; // -
        public static int DMUL = 107; // -
        public static int IDIV = 108; // -
        public static int LDIV = 109; // -
        public static int FDIV = 110; // -
        public static int DDIV = 111; // -
        public static int IREM = 112; // -
        public static int LREM = 113; // -
        public static int FREM = 114; // -
        public static int DREM = 115; // -
        public static int INEG = 116; // -
        public static int LNEG = 117; // -
        public static int FNEG = 118; // -
        public static int DNEG = 119; // -
        public static int ISHL = 120; // -
        public static int LSHL = 121; // -
        public static int ISHR = 122; // -
        public static int LSHR = 123; // -
        public static int IUSHR = 124; // -
        public static int LUSHR = 125; // -
        public static int IAND = 126; // -
        public static int LAND = 127; // -
        public static int IOR = 128; // -
        public static int LOR = 129; // -
        public static int IXOR = 130; // -
        public static int LXOR = 131; // -
        public static int IINC = 132; // visitIincInsn
        public static int I2L = 133; // visitInsn
        public static int I2F = 134; // -
        public static int I2D = 135; // -
        public static int L2I = 136; // -
        public static int L2F = 137; // -
        public static int L2D = 138; // -
        public static int F2I = 139; // -
        public static int F2L = 140; // -
        public static int F2D = 141; // -
        public static int D2I = 142; // -
        public static int D2L = 143; // -
        public static int D2F = 144; // -
        public static int I2B = 145; // -
        public static int I2C = 146; // -
        public static int I2S = 147; // -
        public static int LCMP = 148; // -
        public static int FCMPL = 149; // -
        public static int FCMPG = 150; // -
        public static int DCMPL = 151; // -
        public static int DCMPG = 152; // -
        public static int IFEQ = 153; // visitJumpInsn
        public static int IFNE = 154; // -
        public static int IFLT = 155; // -
        public static int IFGE = 156; // -
        public static int IFGT = 157; // -
        public static int IFLE = 158; // -
        public static int IF_ICMPEQ = 159; // -
        public static int IF_ICMPNE = 160; // -
        public static int IF_ICMPLT = 161; // -
        public static int IF_ICMPGE = 162; // -
        public static int IF_ICMPGT = 163; // -
        public static int IF_ICMPLE = 164; // -
        public static int IF_ACMPEQ = 165; // -
        public static int IF_ACMPNE = 166; // -
        public static int GOTO = 167; // -
        public static int JSR = 168; // -
        public static int RET = 169; // visitVarInsn
        public static int TABLESWITCH = 170; // visiTableSwitchInsn
        public static int LOOKUPSWITCH = 171; // visitLookupSwitch
        public static int IRETURN = 172; // visitInsn
        public static int LRETURN = 173; // -
        public static int FRETURN = 174; // -
        public static int DRETURN = 175; // -
        public static int ARETURN = 176; // -
        public static int RETURN = 177; // -
        public static int GETconst = 178; // visitFieldInsn
        public static int PUTconst = 179; // -
        public static int GETFIELD = 180; // -
        public static int PUTFIELD = 181; // -
        public static int INVOKEVIRTUAL = 182; // visitMethodInsn
        public static int INVOKESPECIAL = 183; // -
        public static int INVOKEconst = 184; // -
        public static int INVOKEINTERFACE = 185; // -
        public static int INVOKEDYNAMIC = 186; // visitInvokeDynamicInsn
        public static int NEW = 187; // visitTypeInsn
        public static int NEWARRAY = 188; // visitIntInsn
        public static int ANEWARRAY = 189; // visitTypeInsn
        public static int ARRAYLENGTH = 190; // visitInsn
        public static int ATHROW = 191; // -
        public static int CHECKCAST = 192; // visitTypeInsn
        public static int INSTANCEOF = 193; // -
        public static int MONITORENTER = 194; // visitInsn
        public static int MONITOREXIT = 195; // -

        // int WIDE = 196; // NOT VISITED
        public static int MULTIANEWARRAY = 197; // visitMultiANewArrayInsn

        public static int IFNULL = 198; // visitJumpInsn
        public static int IFNONNULL = 199; // -
        // int GOTO_W = 200; // -
        // int JSR_W = 201; // -
    }
}
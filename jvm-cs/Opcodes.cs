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

        public const int V1_1 = 3 << 16 | 45;
        public const int V1_2 = 0 << 16 | 46;
        public const int V1_3 = 0 << 16 | 47;
        public const int V1_4 = 0 << 16 | 48;
        public const int V1_5 = 0 << 16 | 49;
        public const int V1_6 = 0 << 16 | 50;
        public const int V1_7 = 0 << 16 | 51;
        public const int V1_8 = 0 << 16 | 52;

        // Access flags

        public const int ACC_PUBLIC = 0x0001; // class, field, method
        public const int ACC_STATIC = 0x0002; // class, field, method
        public const int ACC_PROTECTED = 0x0004; // class, field, method
        public const int ACC_const = 0x0008; // field, method
        public const int ACC_FINAL = 0x0010; // class, field, method, parameter
        public const int ACC_SUPER = 0x0020; // class
        public const int ACC_SYNCHRONIZED = 0x0020; // method
        public const int ACC_VOLATILE = 0x0040; // field
        public const int ACC_BRIDGE = 0x0040; // method
        public const int ACC_VARARGS = 0x0080; // method
        public const int ACC_TRANSIENT = 0x0080; // field
        public const int ACC_NATIVE = 0x0100; // method
        public const int ACC_INTERFACE = 0x0200; // class
        public const int ACC_ABSTRACT = 0x0400; // class, method
        public const int ACC_STRICT = 0x0800; // method
        public const int ACC_SYNTHETIC = 0x1000; // class, field, method, parameter
        public const int ACC_ANNOTATION = 0x2000; // class
        public const int ACC_ENUM = 0x4000; // class(?) field inner
        public const int ACC_MANDATED = 0x8000; // parameter

        // ASM specific pseudo Access flags

        public const int ACC_DEPRECATED = 0x20000; // class, field, method

        // types for NEWARRAY

        public const int T_BOOLEAN = 4;
        public const int T_CHAR = 5;
        public const int T_FLOAT = 6;
        public const int T_DOUBLE = 7;
        public const int T_BYTE = 8;
        public const int T_SHORT = 9;
        public const int T_INT = 10;
        public const int T_LONG = 11;

        // tags for Handle

        public const int H_GETFIELD = 1;
        public const int H_GETconst = 2;
        public const int H_PUTFIELD = 3;
        public const int H_PUTconst = 4;
        public const int H_INVOKEVIRTUAL = 5;
        public const int H_INVOKEconst = 6;
        public const int H_INVOKESPECIAL = 7;
        public const int H_NEWINVOKESPECIAL = 8;
        public const int H_INVOKEINTERFACE = 9;

        // stack map frame types

        /**
         * Represents an expanded frame. See {@link ClassReader#EXPAND_FRAMES}.
         */
        public const int F_NEW = -1;

        /**
         * Represents a compressed frame with complete frame data.
         */
        public const int F_FULL = 0;

        /**
         * Represents a compressed frame where locals are the same as the locals in
         * the previous frame, except that additional 1-3 locals are defined, and
         * with an empty stack.
         */
        public const int F_APPEND = 1;

        /**
         * Represents a compressed frame where locals are the same as the locals in
         * the previous frame, except that the last 1-3 locals are absent and with
         * an empty stack.
         */
        public const int F_CHOP = 2;

        /**
         * Represents a compressed frame with exactly the same locals as the
         * previous frame and with an empty stack.
         */
        public const int F_SAME = 3;

        /**
         * Represents a compressed frame with exactly the same locals as the
         * previous frame and with a single value on the stack.
         */
        public const int F_SAME1 = 4;

        // opcodes // visit method (- = idem)

        public const byte NOP = 0; // visitInsn
        public const byte ACONST_NULL = 1; // -
        public const byte ICONST_M1 = 2; // -
        public const byte ICONST_0 = 3; // -
        public const byte ICONST_1 = 4; // -
        public const byte ICONST_2 = 5; // -
        public const byte ICONST_3 = 6; // -
        public const byte ICONST_4 = 7; // -
        public const byte ICONST_5 = 8; // -
        public const byte LCONST_0 = 9; // -
        public const byte LCONST_1 = 10; // -
        public const byte FCONST_0 = 11; // -
        public const byte FCONST_1 = 12; // -
        public const byte FCONST_2 = 13; // -
        public const byte DCONST_0 = 14; // -
        public const byte DCONST_1 = 15; // -
        public const byte BIPUSH = 16; // visitIntInsn
        public const byte SIPUSH = 17; // -
        public const byte LDC = 18; // visitLdcInsn

        // int LDC_W = 19; // -
        // int LDC2_W = 20; // -
        public const byte ILOAD = 21; // visitVarInsn
                      
        public const byte LLOAD = 22; // -
        public const byte FLOAD = 23; // -
        public const byte DLOAD = 24; // -
        public const byte ALOAD = 25; // -

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
        public const byte IALOAD = 46; // visitInsn
                      
        public const byte LALOAD = 47; // -
        public const byte FALOAD = 48; // -
        public const byte DALOAD = 49; // -
        public const byte AALOAD = 50; // -
        public const byte BALOAD = 51; // -
        public const byte CALOAD = 52; // -
        public const byte SALOAD = 53; // -
        public const byte ISTORE = 54; // visitVarInsn
        public const byte LSTORE = 55; // -
        public const byte FSTORE = 56; // -
        public const byte DSTORE = 57; // -
        public const byte ASTORE = 58; // -

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
        public const byte IASTORE = 79; // visitInsn
                    
        public const byte LASTORE = 80; // -
        public const byte FASTORE = 81; // -
        public const byte DASTORE = 82; // -
        public const byte AASTORE = 83; // -
        public const byte BASTORE = 84; // -
        public const byte CASTORE = 85; // -
        public const byte SASTORE = 86; // -
        public const byte POP = 87; // -
        public const byte POP2 = 88; // -
        public const byte DUP = 89; // -
        public const byte DUP_X1 = 90; // -
        public const byte DUP_X2 = 91; // -
        public const byte DUP2 = 92; // -
        public const byte DUP2_X1 = 93; // -
        public const byte DUP2_X2 = 94; // -
        public const byte SWAP = 95; // -
        public const byte IADD = 96; // -
        public const byte LADD = 97; // -
        public const byte FADD = 98; // -
        public const byte DADD = 99; // -
        public const byte ISUB = 100; // -
        public const byte LSUB = 101; // -
        public const byte FSUB = 102; // -
        public const byte DSUB = 103; // -
        public const byte IMUL = 104; // -
        public const byte LMUL = 105; // -
        public const byte FMUL = 106; // -
        public const byte DMUL = 107; // -
        public const byte IDIV = 108; // -
        public const byte LDIV = 109; // -
        public const byte FDIV = 110; // -
        public const byte DDIV = 111; // -
        public const byte IREM = 112; // -
        public const byte LREM = 113; // -
        public const byte FREM = 114; // -
        public const byte DREM = 115; // -
        public const byte INEG = 116; // -
        public const byte LNEG = 117; // -
        public const byte FNEG = 118; // -
        public const byte DNEG = 119; // -
        public const byte ISHL = 120; // -
        public const byte LSHL = 121; // -
        public const byte ISHR = 122; // -
        public const byte LSHR = 123; // -
        public const byte IUSHR = 124; // -
        public const byte LUSHR = 125; // -
        public const byte IAND = 126; // -
        public const byte LAND = 127; // -
        public const byte IOR = 128; // -
        public const byte LOR = 129; // -
        public const byte IXOR = 130; // -
        public const byte LXOR = 131; // -
        public const byte IINC = 132; // visitIincInsn
        public const byte I2L = 133; // visitInsn
        public const byte I2F = 134; // -
        public const byte I2D = 135; // -
        public const byte L2I = 136; // -
        public const byte L2F = 137; // -
        public const byte L2D = 138; // -
        public const byte F2I = 139; // -
        public const byte F2L = 140; // -
        public const byte F2D = 141; // -
        public const byte D2I = 142; // -
        public const byte D2L = 143; // -
        public const byte D2F = 144; // -
        public const byte I2B = 145; // -
        public const byte I2C = 146; // -
        public const byte I2S = 147; // -
        public const byte LCMP = 148; // -
        public const byte FCMPL = 149; // -
        public const byte FCMPG = 150; // -
        public const byte DCMPL = 151; // -
        public const byte DCMPG = 152; // -
        public const byte IFEQ = 153; // visitJumpInsn
        public const byte IFNE = 154; // -
        public const byte IFLT = 155; // -
        public const byte IFGE = 156; // -
        public const byte IFGT = 157; // -
        public const byte IFLE = 158; // -
        public const byte IF_ICMPEQ = 159; // -
        public const byte IF_ICMPNE = 160; // -
        public const byte IF_ICMPLT = 161; // -
        public const byte IF_ICMPGE = 162; // -
        public const byte IF_ICMPGT = 163; // -
        public const byte IF_ICMPLE = 164; // -
        public const byte IF_ACMPEQ = 165; // -
        public const byte IF_ACMPNE = 166; // -
        public const byte GOTO = 167; // -
        public const byte JSR = 168; // -
        public const byte RET = 169; // visitVarInsn
        public const byte TABLESWITCH = 170; // visiTableSwitchInsn
        public const byte LOOKUPSWITCH = 171; // visitLookupSwitch
        public const byte IRETURN = 172; // visitInsn
        public const byte LRETURN = 173; // -
        public const byte FRETURN = 174; // -
        public const byte DRETURN = 175; // -
        public const byte ARETURN = 176; // -
        public const byte RETURN = 177; // -
        public const byte GETSTATIC = 178; // visitFieldInsn
        public const byte PUTSTATIC = 179; // -
        public const byte GETFIELD = 180; // -
        public const byte PUTFIELD = 181; // -
        public const byte INVOKEVIRTUAL = 182; // visitMethodInsn
        public const byte INVOKESPECIAL = 183; // -
        public const byte INVOKESTATIC = 184; // -
        public const byte INVOKEINTERFACE = 185; // -
        public const byte INVOKEDYNAMIC = 186; // visitInvokeDynamicInsn
        public const byte NEW = 187; // visitTypeInsn
        public const byte NEWARRAY = 188; // visitIntInsn
        public const byte ANEWARRAY = 189; // visitTypeInsn
        public const byte ARRAYLENGTH = 190; // visitInsn
        public const byte ATHROW = 191; // -
        public const byte CHECKCAST = 192; // visitTypeInsn
        public const byte INSTANCEOF = 193; // -
        public const byte MONITORENTER = 194; // visitInsn
        public const byte MONITOREXIT = 195; // -
        public const byte WIDE = 196;
                     
        // int WIDE = byte; // NOT VISITED
        public const byte MULTIANEWARRAY = 197; // visitMultiANewArrayInsn
                      
        public const byte IFNULL = 198; // visitJumpInsn
        public const byte IFNONNULL = 199; // -
        // int GOTO_W = 200; // -
        // int JSR_W = 201; // -
    }
}
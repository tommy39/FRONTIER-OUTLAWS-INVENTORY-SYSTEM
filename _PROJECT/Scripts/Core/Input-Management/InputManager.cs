using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace IND.Core.Inputs
{
    public class InputManager : IND_Mono
    {
        public ScriptableFloat deltaTime;
        public ScriptableFloat fixedDeltaTime;

        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey00_Input;
        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey01_Input;
        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey02_Input;
        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey03_Input;
        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey04_Input;
        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey05_Input;
        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey06_Input;
        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey07_Input;
        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey08_Input;
        [FoldoutGroup("Alpha Key Inputs")] public ScriptableBool alphaKey09_Input;

        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f1ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f2ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f3ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f4ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f5ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f6ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f7ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f8ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f9ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f10ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f11ActionKey_Input;
        [FoldoutGroup("F Action Key Inputs")] public ScriptableBool f12ActionKey_Input;

        [FoldoutGroup("Command Key Inputs")] public ScriptableBool consoleTildaKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool escapeKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool tabKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool capsLockKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool leftShiftKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool leftShiftKey_Held_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool leftControlKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool leftFunctionKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool leftWindowsKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool leftAlt_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool spacebarKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool altGrKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool rightFunctionKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool actionKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool rightControlKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool rightShiftKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool enterKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool backspaceKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool equalKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool minusKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool deleteKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool endKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool pageDownKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool pageUpKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool homeKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool insertKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool leftBracketKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool rightBracketKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool semiColonKey;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool atKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool hashTagKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool lessKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool greaterKey_Input;
        [FoldoutGroup("Command Key Inputs")] public ScriptableBool questionMarkKey_Input;

        [FoldoutGroup("Command Key Inputs/Arrow Keys")] public ScriptableBool upKey_Input;
        [FoldoutGroup("Command Key Inputs/Arrow Keys")] public ScriptableBool downKey_Input;
        [FoldoutGroup("Command Key Inputs/Arrow Keys")] public ScriptableBool rightKey_Input;
        [FoldoutGroup("Command Key Inputs/Arrow Keys")] public ScriptableBool leftKey_Input;

        [FoldoutGroup("Command Key Inputs/Numpad")] public ScriptableBool numpadNumLockKey_Input;
        [FoldoutGroup("Command Key Inputs/Numpad")] public ScriptableBool numpadDivideKey_Input;
        [FoldoutGroup("Command Key Inputs/Numpad")] public ScriptableBool numpadMultiplyKey_Input;
        [FoldoutGroup("Command Key Inputs/Numpad")] public ScriptableBool numpadMinusKey_Input;
        [FoldoutGroup("Command Key Inputs/Numpad")] public ScriptableBool numpadPlusKey_Input;
        [FoldoutGroup("Command Key Inputs/Numpad")] public ScriptableBool numpadEnterKey_Input;
        [FoldoutGroup("Command Key Inputs/Numpad")] public ScriptableBool numpadDeleteKey_Input;
        [FoldoutGroup("Command Key Inputs/Numpad")] public ScriptableBool numpadInsertKey_Input;

        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool q_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool w_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool e_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool r_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool t_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool y_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool u_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool i_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool o_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool p_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool a_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool s_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool d_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool f_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool g_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool h_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool j_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool k_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool l_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool z_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool x_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool c_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool v_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool b_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool n_Input;
        [FoldoutGroup("Letter Key Inputs")] public ScriptableBool M_Input;


        [FoldoutGroup("Controller Inputs")] public ScriptableFloat vertical_Input;
        [FoldoutGroup("Controller Inputs")] public ScriptableFloat horizontal_Input;

        [FoldoutGroup("Mouse Inputs")] public ScriptableVector3 mouseWorldPos;
        [FoldoutGroup("Mouse Inputs")] public ScriptableBool leftClick_Held_Input;
        [FoldoutGroup("Mouse Inputs")] public ScriptableBool leftClick_PressedDown_Input;
        [FoldoutGroup("Mouse Inputs")] public ScriptableBool leftClick_Released_Input;
        [FoldoutGroup("Mouse Inputs")] public ScriptableBool rightClick_Held_Input;
        [FoldoutGroup("Mouse Inputs")] public ScriptableBool rightClick_Pressed_Input;
        [FoldoutGroup("Mouse Inputs")] public ScriptableVector3 mouseScroll_Input;

        public override void Init()
        {
            ResetRegularInput();
        }

        public override void Tick()
        {
            deltaTime.value = Time.deltaTime;
            GetRegularInput();
        }
        public override void FixedTick()
        {
            fixedDeltaTime.value = Time.fixedDeltaTime;
            GetFixedInput();
        }

        private void GetFixedInput()
        {

        }
        private void GetRegularInput()
        {
            GetAlphaKeyInputs();
            GetFActionkeyInputs();
            GetCommandKeyInputs();
            GetLetterKeyInputs();
            GetControllerInputs();
            GetMouseInputs();
        }

        void GetAlphaKeyInputs()
        {
            alphaKey00_Input.value = Input.GetKeyDown(KeyCode.Alpha0);
            alphaKey01_Input.value = Input.GetKeyDown(KeyCode.Alpha1);
            alphaKey02_Input.value = Input.GetKeyDown(KeyCode.Alpha2);
            alphaKey03_Input.value = Input.GetKeyDown(KeyCode.Alpha3);
            alphaKey04_Input.value = Input.GetKeyDown(KeyCode.Alpha4);
            alphaKey05_Input.value = Input.GetKeyDown(KeyCode.Alpha5);
            alphaKey06_Input.value = Input.GetKeyDown(KeyCode.Alpha6);
            alphaKey07_Input.value = Input.GetKeyDown(KeyCode.Alpha7);
            alphaKey08_Input.value = Input.GetKeyDown(KeyCode.Alpha8);
            alphaKey09_Input.value = Input.GetKeyDown(KeyCode.Alpha9);

        }

        void GetFActionkeyInputs()
        {
            f1ActionKey_Input.value = Input.GetKeyDown(KeyCode.F1);
            f2ActionKey_Input.value = Input.GetKeyDown(KeyCode.F2);
            f3ActionKey_Input.value = Input.GetKeyDown(KeyCode.F3);
            f4ActionKey_Input.value = Input.GetKeyDown(KeyCode.F4);
            f5ActionKey_Input.value = Input.GetKeyDown(KeyCode.F5);
            f6ActionKey_Input.value = Input.GetKeyDown(KeyCode.F6);
            f7ActionKey_Input.value = Input.GetKeyDown(KeyCode.F7);
            f8ActionKey_Input.value = Input.GetKeyDown(KeyCode.F8);
            f9ActionKey_Input.value = Input.GetKeyDown(KeyCode.F9);
            f10ActionKey_Input.value = Input.GetKeyDown(KeyCode.F10);
            f11ActionKey_Input.value = Input.GetKeyDown(KeyCode.F11);
            f12ActionKey_Input.value = Input.GetKeyDown(KeyCode.F12);

        }

        void GetCommandKeyInputs()
        {
            escapeKey_Input.value = Input.GetKeyDown(KeyCode.Escape);
            consoleTildaKey_Input.value = Input.GetKeyDown(KeyCode.Tilde);
            tabKey_Input.value = Input.GetKeyDown(KeyCode.Tab);
            capsLockKey_Input.value = Input.GetKeyDown(KeyCode.CapsLock);
            leftShiftKey_Input.value = Input.GetKeyDown(KeyCode.LeftShift);
            leftShiftKey_Held_Input.value = Input.GetKey(KeyCode.LeftShift);
            leftFunctionKey_Input.value = Input.GetKeyDown(KeyCode.LeftCommand);
            rightFunctionKey_Input.value = Input.GetKeyDown(KeyCode.RightCommand);
            leftWindowsKey_Input.value = Input.GetKeyDown(KeyCode.LeftWindows);
            leftAlt_Input.value = Input.GetKeyDown(KeyCode.LeftAlt);
            spacebarKey_Input.value = Input.GetKeyDown(KeyCode.Space);
            altGrKey_Input.value = Input.GetKeyDown(KeyCode.AltGr);
            rightShiftKey_Input.value = Input.GetKeyDown(KeyCode.RightShift);
            enterKey_Input.value = Input.GetKeyDown(KeyCode.Return);
            backspaceKey_Input.value = Input.GetKeyDown(KeyCode.Backspace);
            equalKey_Input.value = Input.GetKeyDown(KeyCode.Equals);
            minusKey_Input.value = Input.GetKeyDown(KeyCode.Minus);
            deleteKey_Input.value = Input.GetKeyDown(KeyCode.Delete);
            endKey_Input.value = Input.GetKeyDown(KeyCode.End);
            pageDownKey_Input.value = Input.GetKeyDown(KeyCode.PageDown);
            pageUpKey_Input.value = Input.GetKeyDown(KeyCode.PageUp);
            homeKey_Input.value = Input.GetKeyDown(KeyCode.Home);
            numpadInsertKey_Input.value = Input.GetKeyDown(KeyCode.Insert);
            leftBracketKey_Input.value = Input.GetKeyDown(KeyCode.LeftBracket);
            rightBracketKey_Input.value = Input.GetKeyDown(KeyCode.RightBracket);
            semiColonKey.value = Input.GetKeyDown(KeyCode.Semicolon);
            atKey_Input.value = Input.GetKeyDown(KeyCode.At);
            hashTagKey_Input.value = Input.GetKeyDown(KeyCode.Hash);
            lessKey_Input.value = Input.GetKeyDown(KeyCode.Less);
            greaterKey_Input.value = Input.GetKeyDown(KeyCode.Greater);
            questionMarkKey_Input.value = Input.GetKeyDown(KeyCode.Question);

            upKey_Input.value = Input.GetKeyDown(KeyCode.UpArrow);
            downKey_Input.value = Input.GetKeyDown(KeyCode.DownArrow);
            rightKey_Input.value = Input.GetKeyDown(KeyCode.RightArrow);
            leftKey_Input.value = Input.GetKeyDown(KeyCode.LeftArrow);

            numpadNumLockKey_Input.value = Input.GetKeyDown(KeyCode.Numlock);
            numpadDivideKey_Input.value = Input.GetKeyDown(KeyCode.KeypadDivide);
            numpadMultiplyKey_Input.value = Input.GetKeyDown(KeyCode.KeypadMultiply);
            numpadMinusKey_Input.value = Input.GetKeyDown(KeyCode.KeypadMinus);
            numpadPlusKey_Input.value = Input.GetKeyDown(KeyCode.KeypadPlus);
            numpadEnterKey_Input.value = Input.GetKeyDown(KeyCode.KeypadEnter);
            numpadDeleteKey_Input.value = Input.GetKeyDown(KeyCode.KeypadPeriod);
            numpadInsertKey_Input.value = Input.GetKeyDown(KeyCode.Insert);

        }

        void GetLetterKeyInputs()
        {
            q_Input.value = Input.GetKeyDown(KeyCode.Q);
            w_Input.value = Input.GetKeyDown(KeyCode.W);
            e_Input.value = Input.GetKeyDown(KeyCode.E);
            r_Input.value = Input.GetKeyDown(KeyCode.R);
            t_Input.value = Input.GetKeyDown(KeyCode.T);
            y_Input.value = Input.GetKeyDown(KeyCode.Y);
            u_Input.value = Input.GetKeyDown(KeyCode.U);
            i_Input.value = Input.GetKeyDown(KeyCode.I);
            o_Input.value = Input.GetKeyDown(KeyCode.O);
            p_Input.value = Input.GetKeyDown(KeyCode.P);
            a_Input.value = Input.GetKeyDown(KeyCode.A);
            s_Input.value = Input.GetKeyDown(KeyCode.S);
            d_Input.value = Input.GetKeyDown(KeyCode.D);
            f_Input.value = Input.GetKeyDown(KeyCode.F);
            g_Input.value = Input.GetKeyDown(KeyCode.G);
            h_Input.value = Input.GetKeyDown(KeyCode.H);
            j_Input.value = Input.GetKeyDown(KeyCode.J);
            k_Input.value = Input.GetKeyDown(KeyCode.K);
            l_Input.value = Input.GetKeyDown(KeyCode.L);
            z_Input.value = Input.GetKeyDown(KeyCode.Z);
            x_Input.value = Input.GetKeyDown(KeyCode.X);
            c_Input.value = Input.GetKeyDown(KeyCode.C);
            v_Input.value = Input.GetKeyDown(KeyCode.V);
            b_Input.value = Input.GetKeyDown(KeyCode.B);
            n_Input.value = Input.GetKeyDown(KeyCode.N);
            M_Input.value = Input.GetKeyDown(KeyCode.M);

        }

        void GetControllerInputs()
        {
            horizontal_Input.value = Input.GetAxisRaw("Horizontal");
            vertical_Input.value = Input.GetAxisRaw("Vertical");
        }

        void GetMouseInputs()
        {
            mouseWorldPos.value = Input.mousePosition;
            leftClick_Held_Input.value = Input.GetMouseButton(0);
            leftClick_PressedDown_Input.value = Input.GetMouseButtonDown(0);
            leftClick_Released_Input.value = Input.GetMouseButtonUp(0);
            rightClick_Held_Input.value = Input.GetMouseButton(1);
            rightClick_Pressed_Input.value = Input.GetMouseButtonDown(1);
            mouseScroll_Input.value = Input.mouseScrollDelta;
        }
        public void ResetRegularInput()
        {
            ResetAlphaKeyInputs();
            ResetFActionKeyInputs();
            ResetCommandKeyInputs();
            ResetLetterKeyInputs();
            ResetMouseInputs();
        }

        private void ResetAlphaKeyInputs()
        {
            alphaKey00_Input.value = false;
            alphaKey01_Input.value = false;
            alphaKey02_Input.value = false;
            alphaKey03_Input.value = false;
            alphaKey04_Input.value = false;
            alphaKey05_Input.value = false;
            alphaKey06_Input.value = false;
            alphaKey07_Input.value = false;
            alphaKey08_Input.value = false;
            alphaKey09_Input.value = false;
        }

        private void ResetFActionKeyInputs()
        {
            f1ActionKey_Input.value = false;
            f2ActionKey_Input.value = false;
            f3ActionKey_Input.value = false;
            f4ActionKey_Input.value = false;
            f5ActionKey_Input.value = false;
            f6ActionKey_Input.value = false;
            f7ActionKey_Input.value = false;
            f8ActionKey_Input.value = false;
            f9ActionKey_Input.value = false;
            f10ActionKey_Input.value = false;
            f11ActionKey_Input.value = false;
            f12ActionKey_Input.value = false;

        }

        private void ResetCommandKeyInputs()
        {
            escapeKey_Input.value = false;
            consoleTildaKey_Input.value = false;
            tabKey_Input.value = false;
            capsLockKey_Input.value = false;
            leftShiftKey_Input.value = false;
            leftFunctionKey_Input.value = false;
            rightFunctionKey_Input.value = false;
            leftWindowsKey_Input.value = false;
            leftAlt_Input.value = false;
            spacebarKey_Input.value = false;
            altGrKey_Input.value = false;
            rightShiftKey_Input.value = false;
            enterKey_Input.value = false;
            backspaceKey_Input.value = false;
            equalKey_Input.value = false;
            minusKey_Input.value = false;
            deleteKey_Input.value = false;
            endKey_Input.value = false;
            pageDownKey_Input.value = false;
            pageUpKey_Input.value = false;
            homeKey_Input.value = false;
            numpadInsertKey_Input.value = false;
            leftBracketKey_Input.value = false;
            rightBracketKey_Input.value = false;
            semiColonKey.value = false;
            atKey_Input.value = false;
            hashTagKey_Input.value = false;
            lessKey_Input.value = false;
            greaterKey_Input.value = false;
            questionMarkKey_Input.value = false;

            upKey_Input.value = false;
            downKey_Input.value = false;
            rightKey_Input.value = false;
            leftKey_Input.value = false;

            numpadNumLockKey_Input.value = false;
            numpadDivideKey_Input.value = false;
            numpadMultiplyKey_Input.value = false;
            numpadMinusKey_Input.value = false;
            numpadPlusKey_Input.value = false;
            numpadEnterKey_Input.value = false;
            numpadDeleteKey_Input.value = false;
            numpadInsertKey_Input.value = false;
        }

        private void ResetLetterKeyInputs()
        {
            q_Input.value = false;
            w_Input.value = false;
            e_Input.value = false;
            r_Input.value = false;
            t_Input.value = false;
            y_Input.value = false;
            u_Input.value = false;
            i_Input.value = false;
            o_Input.value = false;
            p_Input.value = false;
            a_Input.value = false;
            s_Input.value = false;
            d_Input.value = false;
            f_Input.value = false;
            g_Input.value = false;
            h_Input.value = false;
            j_Input.value = false;
            k_Input.value = false;
            l_Input.value = false;
            z_Input.value = false;
            x_Input.value = false;
            c_Input.value = false;
            v_Input.value = false;
            b_Input.value = false;
            n_Input.value = false;
            M_Input.value = false;
        }

        void ResetMouseInputs()
        {
            rightClick_Pressed_Input.value = false;
            leftClick_Released_Input.value = false;
            leftClick_PressedDown_Input.value = false;
        }
        public void ResetFixedInput()
        {

        }
    }


}
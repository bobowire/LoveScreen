using LoveScreen.Windows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace LoveScreen.Windows.Procs
{
    public static class HotkeyListener
    {
        /// <summary>
        ///     热键消息
        /// </summary>
        const int WindowsMessageHotkey = 786;
        /// <summary>
        ///     demo的实例句柄
        /// </summary>
        public static IExcuteHotKey Instance = null;
        static Dictionary<Hotkey, List<IExcuteHotKey>> m_keyPool = new Dictionary<Hotkey, List<IExcuteHotKey>>();
        static HotkeyListener()
        {
            //  注册热键（调用windows API实现，与winform一致）
            //Hotkey hotkey = new Hotkey(Keys.F2, Modifiers.None, true);
            //  处理热键消息（使用wpf的键盘处理）
            ComponentDispatcher.ThreadPreprocessMessage += (ref MSG Message, ref bool Handled) =>
            {
                //  判断是否热键消息
                if (Message.message == WindowsMessageHotkey)
                {
                    //  获取热键id
                    var id = Message.wParam.ToInt32();
                    //  执行热键回调方法（执行时需要判断是否与注册的热键匹配）
                    //Instance.ExcuteHotKeyCommand(id);
                    Hotkey keyIns = m_keyPool.Keys.FirstOrDefault(t => t.Id == id);
                    if (keyIns != null)
                    {
                        for (int i = m_keyPool[keyIns].Count - 1; i >= 0; i--)
                        {
                            IExcuteHotKey instance = m_keyPool[keyIns][i];
                            if (instance.IsEffective()) instance.ExcuteHotKeyCommand(id);
                            else m_keyPool[keyIns].Remove(instance);
                        }
                    }
                }
            };
        }
        public static void SetHotKeyHandle(IExcuteHotKey obj, Keys key, Modifiers modifiers)
        {
            Hotkey hotkey = m_keyPool.Keys.FirstOrDefault(t => t.Key == key && t.Modifiers == modifiers);
            if (hotkey != null)
            {
                if (!m_keyPool[hotkey].Contains(obj))
                    m_keyPool[hotkey].Add(obj);
            }
            else
            {
                m_keyPool.Add(new Hotkey(key, modifiers, true), new List<IExcuteHotKey>() { obj });
            }
        }
    }
}

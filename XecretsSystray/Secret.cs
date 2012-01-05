using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XecretsSystray
{
    class Secret
    {
        public string m_title;
        public string m_content;
        public string m_guid;

        public Secret(string title, string content, string guid)
        {
            m_title = title;
            m_content = content;
            m_guid = guid;
        }

        public override string ToString()
        {
            return m_title;
        }
    }
}

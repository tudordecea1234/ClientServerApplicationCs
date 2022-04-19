﻿using System;

namespace services
{
    public class TeledonException:Exception
    {
        public TeledonException():base() { }

        public TeledonException(String msg) : base(msg) { }

        public TeledonException(String msg, Exception ex) : base(msg, ex) { }

    }
}
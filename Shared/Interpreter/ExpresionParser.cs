using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interpreter
{
    public class ExpresionParser
    {
        Context context;
        Player player;

        public ExpresionParser(Context context)
        {
            this.context = context;
        }


        public void parse()
        {
            string[] token = context.Input.Split(" ");

            if (token.Length < 4)
            {
                context.Result = "Command do not exist";
                return;
            }
            player = (Player) new PlayerExpresion(token[0]).intepret();

            if(player == null)
            {
                context.Result =  "Player do not Exist";
                return;
            }

            if (token[1] == "give")
            {
                if(token[2] == "coins")
                {
                    new AdvanceGiveCoinsExpresion(player, new NumberExpresion(token[3])).intepret();
                }else if (token[2] == "health")
                {
                    new AdvanceGiveHealthExpresion(player, new NumberExpresion(token[3])).intepret();
                }
                else
                {
                    context.Result = "Wrong Item";
                    return;
                }
            }
            else
            {
                context.Result = "Wrong command";
                return;
            }

            context.Result = "Command was completed";
        }
    }
}

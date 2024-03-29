﻿using MySupermarket.Common.Event;
using MySupermarket.Core.Domain;
using MySupermarket.Services.Interfaces;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupermarket.Common.Extensions
{
    public static class DialogExtension
    {
        /// <summary>
        /// 推送等待消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="action"></param>
        public static void UpdateLoading(this IEventAggregator aggregator, UpdateModel model)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Publish(model);
        }

        /// <summary>
        /// 注册等待消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="model"></param>
        public static void Resgiter(this IEventAggregator aggregator, Action<UpdateModel> model)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(model);
        }

        /// <summary>
        /// 询问窗口
        /// </summary>
        /// <param name="dialogHost">指定的DialogHost会话主机</param>
        /// <param name="title">标题</param>
        /// <param name="content">询问内容</param>
        /// <param name="dialogHostName">会话主机名称(唯一)</param>
        /// <returns></returns>
        public static async Task<IDialogResult> Question(this IDialogHostService dialogHost,
            string title, string content, string dialogHostName = "Root"
            )
        {
            DialogParameters param = new DialogParameters();
            param.Add("Title", title);
            param.Add("Content", content);
            param.Add("dialogHostName", dialogHostName);
            var dialogResult = await dialogHost.ShowDialogAsync("MessageView", param, dialogHostName);
            return dialogResult;
        }

        /// <summary>
        /// 注册提示消息事件
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="model"></param>
        public static void ResgiterHintMessage(this IEventAggregator aggregator, Action<MessageModel> model, string filterName = "MainWindow")
        {
            aggregator.GetEvent<HintMessageEvent>().Subscribe(model, ThreadOption.PublisherThread, true, x =>
            {
                return x.Filter.Equals(filterName);
            });
        }

        /// <summary>
        /// 推送提示消息事件
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="model"></param>
        public static void SendHintMessage(this IEventAggregator aggregator, string message, string filterName = "MainWindow")
        {
            aggregator.GetEvent<HintMessageEvent>().Publish(new MessageModel()
            {
                Filter = filterName,
                Message = message
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.VoiceCommands;

namespace CortanaSampleService
{
    public sealed class SampleVoiceService : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var serviceDeferral = taskInstance.GetDeferral();
            var triggerDetails = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            if (triggerDetails != null && triggerDetails.Name == "VoiceAppService")
            {
                var voiceServiceConnection = VoiceCommandServiceConnection.FromAppServiceTriggerDetails(triggerDetails);
                var voiceCommand = await voiceServiceConnection.GetVoiceCommandAsync();

                var commandName = voiceCommand.CommandName; //コマンド名
                var number = voiceCommand.SpeechRecognitionResult.SemanticInterpretation.Properties["number"][0];   //{}内のパラメータ
                var status = voiceCommand.SpeechRecognitionResult.Status;   //認識ステータス
                var text = voiceCommand.SpeechRecognitionResult.Text;   //認識した言葉

                //ここにレスポンス処理を書く
                string questionMessage = "～処理を実行してもいいですか？";
                var messageQuestion = new VoiceCommandUserMessage();
                messageQuestion.SpokenMessage = questionMessage;
                messageQuestion.DisplayMessage = questionMessage;

                string responseMessage = "了解しました";
                var messageResponse = new VoiceCommandUserMessage();
                messageResponse.SpokenMessage = responseMessage;
                messageResponse.DisplayMessage = responseMessage;

                var contentTiles = new List<VoiceCommandContentTile>();

                var tile1 = new VoiceCommandContentTile();
                tile1.ContentTileType = VoiceCommandContentTileType.TitleWith68x92IconAndText;
                tile1.Title = "選択肢1";
                tile1.TextLine1 = "タイル1";
                contentTiles.Add(tile1);

                var tile2 = new VoiceCommandContentTile();
                tile2.ContentTileType = VoiceCommandContentTileType.TitleWith68x92IconAndText;
                tile2.Title = "選択肢2";
                tile2.TextLine1 = "タイル2";
                contentTiles.Add(tile2);

                var response = VoiceCommandResponse.CreateResponseForPrompt(messageQuestion, messageResponse,contentTiles);
                var result = await voiceServiceConnection.RequestDisambiguationAsync(response);
                
                
            }

            serviceDeferral.Complete();
        }
    }
}

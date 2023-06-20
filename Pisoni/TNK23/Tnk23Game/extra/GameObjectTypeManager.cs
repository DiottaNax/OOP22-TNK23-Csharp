using System.Text.Json;
using System.Diagnostics;


namespace Tnk23Game.extra
{
    public static class GameObjectTypeManager
    {
        private static readonly TraceSource Logger = new TraceSource("TypeObjectFactoryLogger");

        private static Dictionary<string, IGameObjectType> RetrieveTypes()
        {
            var toReturn = new Dictionary<string, IGameObjectType>();

            try
            {
                using (var reader = new StreamReader("it/unibo/objectTypes.json"))
                {
                    var json = reader.ReadToEnd();
                    var jsonArray = JsonDocument.Parse(json).RootElement;


                    foreach (var jsonObject in jsonArray.EnumerateArray())
                    {
                        var typeName = jsonObject.GetProperty("type").GetString();
                        if (typeName != null)
                        {
                            var height = jsonObject.GetProperty("height").GetInt64();
                            var width = jsonObject.GetProperty("width").GetInt64();
                            var speed = jsonObject.GetProperty("speed").GetDouble();
                            var health = jsonObject.GetProperty("health").GetInt64();

                            var gameObjectType = new IGameObjectTypeImpl(height, width, speed, health);
                            toReturn.Add(typeName, gameObjectType);
                        }
                        else
                        {
                            Logger.TraceEvent(TraceEventType.Warning, 0, "Type name is null. Skipping the entry.");
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Logger.TraceEvent(TraceEventType.Error, 0, $"Json file about types not found: {e}");
            }
            catch (JsonException e)
            {
                Logger.TraceEvent(TraceEventType.Error, 0, $"Error while parsing json array: {e}");
            }

            return toReturn;
        }

        public static String GetEnemyType() => "enemy";

        public static String GetBulletType() => "bullet";

        internal static double GetWidth(Type actorType) => throw new NotImplementedException();
            

        internal static bool IsObstacle(Type type) => throw new NotImplementedException();
    }
}

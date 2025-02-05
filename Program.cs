using System.Security.Cryptography.X509Certificates;

namespace TxtRPG
{
    //플레이어 클래스에 플레이어가 가진 속성들 저장
    public class Player
    {
        public int level = 1;
        public string name = "Chad";
        public string job = "전사";
        public int atk = 10;
        public int def = 5;
        public int hp = 100;
        public int gold = 1500;

        public bool[] inventory = new bool[6]; //6칸짜리 인벤토리 만들 배열, 아이템을 소지한 상태인지 아닌지 여부를 봐야 하니 bool로 선언
        public void PlayerInven() //인벤토리 메서드
        {
            for (int i = 0; i < 6; i++) //반복문으로 인벤토리 6칸 생성
            {
                inventory[i] = false; //소지품 없이 시작해야 하니 게임 시작 초기값은 전부 false로 초기화
            }
        }
    }

    //아이템 클래스에 아이템이 가진 속성들 저장
    public class Item
    {
        public string name = "";
        public int itematk = 0;
        public int itemdef = 0;
        public string flavortxt = "";
        public int price = 0;
        public bool bought = false; //구매 여부
        public bool equiped = false; //장착 여부

        public Item[] itemArr = new Item[6]; //아이템 총 6종, 아이템 저장할 배열
        public void ItemInfo()
        {
            for (int i = 0; i < 6; i++)
            {
                itemArr[i] = new Item();
            }

            //배열로 만든 아이템 6개에 각각 정보 저장
            itemArr[0].name = "수련자 갑옷";
            itemArr[0].itematk = 0;
            itemArr[0].itemdef = 5;
            itemArr[0].flavortxt = "수련에 도움을 주는 갑옷입니다.";
            itemArr[0].price = 1000;

            itemArr[1].name = "무쇠 갑옷";
            itemArr[1].itematk = 0;
            itemArr[1].itemdef = 9;
            itemArr[1].flavortxt = "무쇠로 만들어져 튼튼한 갑옷입니다.";
            itemArr[1].price = 2000;

            itemArr[2].name = "스파르타의 갑옷";
            itemArr[2].itematk = 0;
            itemArr[2].itemdef = 15;
            itemArr[2].flavortxt = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
            itemArr[2].price = 3500;

            itemArr[3].name = "낡은 검";
            itemArr[3].itematk = 2;
            itemArr[3].itemdef = 0;
            itemArr[3].flavortxt = "쉽게 볼 수 있는 낡은 검입니다.";
            itemArr[3].price = 3500;

            itemArr[4].name = "청동 도끼";
            itemArr[4].itematk = 5;
            itemArr[4].itemdef = 0;
            itemArr[4].flavortxt = "어디선가 사용됐던 것 같은 도끼입니다.";
            itemArr[4].price = 1500;

            itemArr[5].name = "스파르타의 창";
            itemArr[5].itematk = 5;
            itemArr[5].itemdef = 0;
            itemArr[5].flavortxt = "스파르타의 전사들이 사용했다는 전설의 창입니다.";
            itemArr[5].price = 1500;
        }
    }

    //게임 씬 클래스, 메인 메뉴나 스테이터스, 상점 등등
    class InGame
    {
        Player player = new Player(); //게임 안에 플레이어 생성
        Item item = new Item();
        
        public void MainMenu()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이 곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int select = int.Parse(Console.ReadLine());  //switch문이 작동할 수 있게 입력한 메뉴를 정수형으로

            switch (select) //입력한 숫자에 따라 메뉴 실행
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    //인벤토리 메뉴 메서드
                    break;
                case 3:
                    ShopMenu();
                    break;
            }
        }
        
        //상태 보기 메뉴
        public void StatusMenu()
        {
            Console.WriteLine("[상태 보기] 캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv. {player.level}");
            Console.WriteLine($"{player.name}, {player.job}");
            Console.WriteLine($"공격력: {player.atk}");
            Console.WriteLine($"방어력: {player.def}");
            Console.WriteLine($"체력: {player.hp}");
            Console.WriteLine($"골드: {player.gold}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write(">>");
            int select = int.Parse(Console.ReadLine());

            switch (select) //입력한 숫자에 따라 메뉴 실행
            {
                case 0:
                    MainMenu();
                    break;
            }
        }

        //인벤토리 메뉴
        public void InventoryMenu()
        {
            Console.WriteLine("[아이템 목록]");

            player.PlayerInven(); //플레이어 인벤토리 호출
            for (int i = 0; i < 6; i++)
            {
                if (player.inventory[i] == true) //인벤토리 배열 값이 트루라면 = 아이템을 소지한 상태라면 출력
                {

                }

            }
          

        }

        //상점 메뉴
        public void ShopMenu()
        {
            Console.WriteLine("[상점] 필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(player.gold + " G");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            item.ItemInfo(); //배열에 저장한 아이템 정보 호출
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"- {item.itemArr[i].name} | 공격력 +{item.itemArr[i].itematk} | 방어력 +{item.itemArr[i].itemdef} | {item.itemArr[i].flavortxt} | {item.itemArr[i].price} G");
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write(">>");
            int select = int.Parse(Console.ReadLine());

            switch (select)
            {
                case 0:
                    MainMenu();
                    break;
            }

        }

     }

        internal class Program
    {
        static void Main(string[] args)
        {
            InGame PLAY = new InGame();
            PLAY.MainMenu(); //게임 메인 메뉴 실행
        }
    }
}

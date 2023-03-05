// Wybór koloru
Console.Write("Cześć, jaki kolor lubisz: ");
string kolor = Console.ReadLine();

switch (kolor)
{
    case "zolty":
        Console.WriteLine("{0} - symbolizuje sławę, żartobliwość, optymizm, ale również chorobę, zdradę, niezdecydowanie oraz nadwrażliwość.", kolor);
        break; 
    case "czerwony":
        Console.WriteLine("{0} - mówi o potrzebie aktywności emocjonalnej i fizycznej. Może informować o słabym krążeniu krwi i niskim ciśnieniu.", kolor);
        break;
    case "niebieski":
        Console.WriteLine("{0} - mówi o potrzebie dokonań, tworzenia czegoś oryginalnego i docenianego, wyraża pragnienie, by inni dostrzegli naszą mądrość i kreatywność.", kolor);
        break;
    case "pomaranczowy":
        Console.WriteLine("Kolor {0} to barwa młodości, kreatywności, lekkości i aktywności. ", kolor);
        break;
    case "fioletowy":
        Console.WriteLine("{0} - to kolor luksusu, elegancji, przepychu, ceremoniału, szlachetności i duchowości (szaty biskupie).", kolor);
        break;
    case "zielony":
        Console.WriteLine("{0} - symbolizuje kłopoty emocjonalne, potrzebę skupienia się na sobie i tęsknotę za równowagą wewnętrzną.", kolor);
        break;
    case "czarny":
        Console.WriteLine("{0} - oznacza koncentrację na sobie, poszukiwanie energii do działania, a także myśli egzystencjalne i tęsknotę za miłością. Jest to też kolor smutku i izolacji (“nie wtrącajcie się w moje sprawy”).", kolor);
        break;
    case "bialy":
        Console.WriteLine("{0} - to kolor symbolizujący czystości i niewinności, a także odnowy życia duchowego", kolor);
        break;
    case "brazowy":
        Console.WriteLine("{0} - symbolizuje zagrożone poczucie bezpieczeństwa, niepewność jutra, brak wiary w siebie i potrzebę stabilizacji; także osłabienie i niskie ciśnienie.", kolor);
        break;
    default:
        Console.WriteLine("{0}... nie no co Ty taki kolor nie istnieje", kolor);
        break;
        
}
Console.ReadKey();




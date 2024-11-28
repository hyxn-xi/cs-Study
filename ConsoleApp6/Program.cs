// 일반화 클래스
using System.Diagnostics.CodeAnalysis;

class MyClass<T> where T : struct //type 제약사항 (값, 클래스 등등..)
{
    public T a;
}
class Program
{
    // 일반화 메소드(함수)
    // 반환형식 함수<형식매개변수(T)>(매개변수 목록){}    T = type
    static void CopyArray<T>(T[] source, T[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    static IEnumerable<int> GetNumber()     // 지연 실행, 분할 처리 할 때 사용
    {
        // yield는 무조건 IEnumerable, IEnumerator 랑만 사용. yield 활용해서 Coroutine 사용 가능(유니티)
        // 함수 호출 시 StartCoroutine("")로 호출 (유니티 엔진)
        yield return 10;                    // 첫 루프에서 리턴되는 값
        yield return 20;                    // 두 번째 루프에서 리턴되는 값
        yield return 30;                    // 세 번째 루프에서 리턴되는 값
    }

    static void Main(string[] args)
    {
        int[] s = {1, 2, 3};
        int[] t = {0, 0, 0};
        CopyArray(s,t);

        List<float> ints = new List<float>();    // <>안에 자료형 자유롭게 기입

        MyClass<int> myclass = new MyClass<int>();  // <>안에 자료형 자유롭게 기입
        // MyClass<string> myclass2 = new MyClass<string>(); 제한을 값으로 둔 경우 오류 -> string은 class타입

        // 아래 컬렉션의 데이타의 총합과 평균을 구하세요
        // List<int> list = new List<int() { 1,2,3,4,5};
        List<int> list = new List<int>() {1,2,3,4,5};
        int sum = 0;
        foreach(int i in list) { sum += i;}
        System.Console.WriteLine(sum);  // 총 합
        System.Console.WriteLine(sum / (double)list.Count);     // 평균

        // Dictionary -> 창고. 자료형만 전달해주면 어떤 자료든 담을 수 있게 자동으로 코드 작성
        Dictionary<string, string> dir = new Dictionary<string, string>();
        dir["하나"] ="one"; 
        dir["둘"] ="two";
        dir["셋"] ="three";
        dir["넷"] ="four";
        dir["다섯"] ="five";
        foreach (var i in dir)                      // foreach문 사용 콘솔에 찍기
        {
            System.Console.WriteLine(i.Value);
        }
        
        // 예외 처리
        // 예외를 처리하지 않으면 CLR이 처리 == 시스템 다운
        // try; catch; throw;
        int[] arr = {1, 2, 3};
        try                                         // 의심스러운 코드 감싸기
        {
            for (int i = 0; i < 5; i++)             // 인덱스 넘버가 배열에 배당된 인덱스보다 큼
            {
            System.Console.WriteLine(arr[i]);       // 실행 시 익셉션 발생
            }
        }
        catch (IndexOutOfRangeException ex)         // 배열 인덱스 관련 예외 클래스
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)                        // Exception -> 광범위하게 문제점을 찾음. 모든 예외 클래스의 조상
        {
            System.Console.WriteLine(ex.Message);   // 조치(문제점 출력)
        }
        finally                                     // 예외가 되든 안되든 무조건 출력함
        {
            System.Console.WriteLine("finally");
        }
        System.Console.WriteLine("End");
    }
}
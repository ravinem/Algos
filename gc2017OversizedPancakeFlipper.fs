module gc2017OversizedPancakeFlipper

let inputfile = "C:\Users\ja13\Desktop\DEE_Output\A-large-practice.in"
let outputfile = "C:\Users\ja13\Desktop\DEE_Output\output.txt"



let rec solve (valuelist:int[]) size (answer:int) (writer:System.IO.StreamWriter) testnum=
    let rec findFirstZeroIndex (index:int) =
        if index = valuelist.Length then
            -1     
        else
            let item = Array.get valuelist index
            if item = 0 then
                index
            else
                findFirstZeroIndex (index+1)
    let firstZeroIndex = findFirstZeroIndex 0  
    let rec findLastZeroIndex (index:int) =
        if index = -1 then
            -1
        else
            let item = Array.get valuelist index
            if item = 0 then
                index
            else
                findLastZeroIndex (index-1)
    let lastZeroIndex = findLastZeroIndex (valuelist.Length-1)
    if firstZeroIndex = -1 then writer.WriteLine("Case #"+testnum+": "+ answer.ToString())
    if firstZeroIndex <> -1 && lastZeroIndex - firstZeroIndex < size - 1 then writer.WriteLine("Case #"+testnum+": "+ "IMPOSSIBLE")
    if firstZeroIndex <> -1 && (lastZeroIndex - firstZeroIndex >= size - 1) then
        let leftList' = valuelist |> Array.map (fun i-> i)
        let rec fillLeftList indx leftList zd= 
            if indx >= firstZeroIndex+size then
                leftList
            else
                let valueitem = Array.get valuelist indx
                if valueitem = 0 then 
                    let valuelist'' = Array.mapi (fun i x-> if i=indx then 1 else x) leftList
                    fillLeftList (indx+1) valuelist'' (zd+1)
                else
                    let valuelist'' = Array.mapi (fun i x-> if i=indx then 0 else x) leftList
                    fillLeftList (indx+1) valuelist'' (zd-1)
        let ll = fillLeftList firstZeroIndex leftList' 0
        solve ll size (answer+1) writer testnum

//[<EntryPoint>]
let main args =
    let reader = new System.IO.StreamReader(inputfile)
    let writer = new System.IO.StreamWriter(outputfile)
    writer.AutoFlush <- true;
    let t = System.Convert.ToInt32(reader.ReadLine())
    let rec recursiveTestcases testnum = 
        if testnum <= t then
            let line = reader.ReadLine().Split(' ')
            let size = System.Convert.ToInt32(line.GetValue(1))
            let valueList = line.GetValue(0).ToString().ToCharArray() |> Array.map (fun x -> if x = '+' then 1 else 0)
            solve valueList size 0 writer (testnum.ToString())
            recursiveTestcases (testnum+1)
        else
            ()
    recursiveTestcases 1
    0

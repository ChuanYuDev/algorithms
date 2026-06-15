namespace Algorithm.DataStructure.SegmentTree;

// Segment tree with sum range, update and query
public class SegmentTree
{
    private readonly int[] _nums;
    private readonly int _length;
    private readonly int[] _segmentTree;

    public SegmentTree(int[] nums)
    {
        _nums = nums;
        _length = nums.Length;
        _segmentTree = new int[_length << 2];
    }

    private void Build(int nodeIdx, int left, int right)
    {
        // Leaf node
        if (left == right)
        {
            _segmentTree[nodeIdx] = _nums[left];
            return;
        }

        int mid = (left + right) >> 1;

        var leftChildIdx = nodeIdx << 1;
        var rightChildIdx = nodeIdx << 1 | 1;

        Build(leftChildIdx, left, mid);
        Build(rightChildIdx, mid + 1, right);

        _segmentTree[nodeIdx] = _segmentTree[leftChildIdx] + _segmentTree[rightChildIdx];
    }

    public void Build()
    {
        Build(1, 0, _length - 1);
    }

    private void Update(int idx, int val, int nodeIdx, int left, int right)
    {
        if (idx < left || idx > right) return;

        // Find the lead node and update its value
        if (left == right)
        {
            _nums[idx] = val;
            _segmentTree[nodeIdx] = val;
            return;
        }

        int mid = (left + right) >> 1;

        var leftChildIdx = nodeIdx << 1;
        var rightChildIdx = nodeIdx << 1 | 1;
        // If node value idx is at the left part then update the left part
        if (idx <= mid) Update(idx, val, leftChildIdx, left, mid);
        else Update(idx, val, rightChildIdx, mid + 1, right);

        // Store the information in parents
        _segmentTree[nodeIdx] = _segmentTree[leftChildIdx] + _segmentTree[rightChildIdx];
    }

    public void Update(int idx, int val)
    {
        Update(idx, val, 1, 0, _length - 1);
    }

    private int Query(int queryLeft, int queryRight, int nodeIdx, int left, int right)
    {
        // If it lies out of range then return 0
        if (queryRight < left || right < queryLeft) return 0;

        // If the node contains the range then return the node value
        if (queryLeft <= left && right <= queryRight) return _segmentTree[nodeIdx];

        int mid = (left + right) >> 1;

        // Recursively traverse left and right and find the node
        return Query(queryLeft, queryRight, nodeIdx << 1, left, mid)
               + Query(queryLeft, queryRight, nodeIdx << 1 | 1, mid + 1, right);
    }

    public int Query(int queryLeft, int queryRight)
    {
        return Query(queryLeft, queryRight, 1, 0, _length - 1);
    }
}

public class MainProgram
{
    static void Main()
    {
        int[] nums = { 0, 1, 3, 5, -2, 3 };
        SegmentTree segmentTree = new SegmentTree(nums);
        
        segmentTree.Build();
        
        // Sum of values in range 0-4 are
        Console.WriteLine(segmentTree.Query(0, 4));
        // Output: 7
        
        // Value at index 1 increased to 101");
        segmentTree.Update(1, 101);
        
        // sum of value in range 1-3 are
        Console.WriteLine(segmentTree.Query(1, 3));
        // Output: 109
    }
}
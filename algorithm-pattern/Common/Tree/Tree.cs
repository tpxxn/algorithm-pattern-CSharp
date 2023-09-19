namespace algorithm_pattern;

public class TreeNode
{
    public int? val;
    public TreeNode? left;
    public TreeNode? right;
    // public int pos;

    public TreeNode(int? val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public static class BinaryTreeBuilder
{
    public static TreeNode Builder(int?[] root)
    {
        var result = new TreeNode();
        // 空树
        if (root.Length == 0 || root[0] == null)
        {
            result.val = null;
            return result;
        }

        result.val = root[0];
        // 只有顶节点的树
        if (root.Length == 1)
        {
            return result;
        }

        // 获取树的层高
        int level = 0;
        int length = root.Length;
        while (length > 0)
        {
            length >>= 1;
            level += 1;
        }

        // 上一层的节点队列
        Queue<TreeNode> lastLevelNodeQueue = new Queue<TreeNode>();
        lastLevelNodeQueue.Enqueue(result);
        // 当前节点-父节点的字典
        Stack<TreeNode> allTreeNodes = new Stack<TreeNode>();
        allTreeNodes.Push(result);
        int pos = 1; // 当前位置
        for (int i = 1; i <= level; i++)
        {
            int count = (int)Math.Pow(2, i);
            for (int j = 0; j < count; j += 2)
            {
                TreeNode parentNode = lastLevelNodeQueue.Dequeue();
                // 左叶子
                var currentPos = pos + j;
                if (currentPos >= root.Length)
                {
                    break;
                }
                TreeNode currentNodeLeft = new TreeNode(root[currentPos]);
                // currentNodeLeft.pos = currentPos;
                parentNode.left = currentNodeLeft;
                lastLevelNodeQueue.Enqueue(currentNodeLeft);
                allTreeNodes.Push(currentNodeLeft);

                //右叶子
                currentPos += 1;
                if (currentPos >= root.Length)
                {
                    break;
                }
                TreeNode currentNodeRight = new TreeNode(root[currentPos]);
                // currentNodeRight.pos = currentPos;
                parentNode.right = currentNodeRight;
                lastLevelNodeQueue.Enqueue(currentNodeRight);
                allTreeNodes.Push(currentNodeRight);
            }
            pos += count;
        }
        // 去除空节点
        while (allTreeNodes.Count > 0)
        {
            var currentNode = allTreeNodes.Pop();
            if (currentNode.val != null)
            {
                if (currentNode.left?.val == null)
                {
                    currentNode.left = null;
                }
                if (currentNode.right?.val == null)
                {
                    currentNode.right = null;
                }
            }
        }
        return result;
    }
}
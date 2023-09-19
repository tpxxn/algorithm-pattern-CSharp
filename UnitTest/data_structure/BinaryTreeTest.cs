using algorithm_pattern;

namespace UnitTest.data_structure;

public class BinaryTreeTest
{
    int?[]? root;
    TreeNode rootTreeNode;

    [SetUp]
    public void Setup()
    {
        root = new int?[] { 5, 4, 7, 3, null, 2, null, -1, null, null, null, 9 };
        rootTreeNode = BinaryTreeBuilder.Builder(root);
    }

    [Test]
    public void BinaryTreeTest_PreorderTraversalRecursion()
    {
        IList<int?> list = BinaryTree.PreorderTraversalRecursion(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 5, 4, 3, -1, 7, 2, 9 }));
    }

    [Test]
    public void BinaryTreeTest_PreorderTraversal()
    {
        IList<int?> list = BinaryTree.PreorderTraversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 5, 4, 3, -1, 7, 2, 9 }));
    }

    [Test]
    public void BinaryTreeTest_InorderTraversal()
    {
        IList<int?> list = BinaryTree.InorderTraversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { -1, 3, 4, 5, 9, 2, 7 }));
    }

    [Test]
    public void BinaryTreeTest_PostorderTraversal()
    {
        IList<int?> list = BinaryTree.PostorderTraversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { -1, 3, 4, 9, 2, 7, 5 }));
    }
}

public class BinaryTreeTest_DFS_BFS
{
    int?[]? root;
    TreeNode rootTreeNode;

    [SetUp]
    public void Setup()
    {
        root = new int?[] { 1, 2, 3, null, 5 };
        rootTreeNode = BinaryTreeBuilder.Builder(root);
    }

    [Test]
    public void BinaryTreeTest_DFS()
    {
        IList<int?> list = BinaryTree.DFS_Traversal(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 1, 2, 5, 3 }));
    }

    [Test]
    public void BinaryTreeTest_DFS_Divide()
    {
        IList<int?> list = BinaryTree.DFS_Traversal_Divide(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 1, 2, 5, 3 }));
    }

    [Test]
    public void BinaryTreeTest_BFS()
    {
        IList<int?> list = BinaryTree.BFS(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<int?> { 1, 2, 3, 5 }));
    }

    #region 257. 二叉树的所有路径

    [Test]
    public void BinaryTreeTest_BinaryTreePaths_BinaryTreePaths()
    {
        IList<string> list = BinaryTree.BinaryTreePaths(rootTreeNode);
        object[] expected = { new List<string> { "1->2->5", "1->3" }, new List<string> { "1->3", "1->2->5" } };
        Assert.That(list, Is.AnyOf(expected));
    }

    [Test]
    public void BinaryTreeTest_BinaryTreePaths_BinaryTreePaths2()
    {
        root = new int?[] { 1 };
        rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<string> list = BinaryTree.BinaryTreePaths(rootTreeNode);
        Assert.That(list, Is.EqualTo(new List<string> { "1" }));
    }

    #endregion
}

public class BinaryTreeTest_Practice
{
    #region 257. 二叉树的所有路径

    [Test]
    public void BinaryTreeTest_IsValidBST()
    {
        int?[] root = { 2, 1, 3 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool isValidBst = BinaryTree.IsValidBST(rootTreeNode);
        Assert.That(isValidBst, Is.EqualTo(true));
    }

    [Test]
    public void BinaryTreeTest_IsValidBST2()
    {
        int?[] root = { 5, 1, 4, null, null, 3, 6 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool isValidBst = BinaryTree.IsValidBST(rootTreeNode);
        Assert.That(isValidBst, Is.EqualTo(false));
    }

    [Test]
    public void BinaryTreeTest_IsValidBST3()
    {
        int?[] root = { 2147483647 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool isValidBst = BinaryTree.IsValidBST(rootTreeNode);
        Assert.That(isValidBst, Is.EqualTo(true));
    }

    #endregion

    #region 257. 二叉树的所有路径

    [Test]
    public void BinaryTreeTest_MaxDepth_DFS()
    {
        int?[] root = { 3, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int maxDepthDfs = BinaryTree.MaxDepth_DFS(rootTreeNode);
        Assert.That(maxDepthDfs, Is.EqualTo(3));
    }

    [Test]
    public void BinaryTreeTest_MaxDepth_DFS2()
    {
        int?[] root = { 1, null, 2 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int maxDepthDfs = BinaryTree.MaxDepth_DFS(rootTreeNode);
        Assert.That(maxDepthDfs, Is.EqualTo(2));
    }

    [Test]
    public void BinaryTreeTest_MaxDepth_BFS()
    {
        int?[] root = { 3, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int maxDepthBfs = BinaryTree.MaxDepth_BFS(rootTreeNode);
        Assert.That(maxDepthBfs, Is.EqualTo(3));
    }

    [Test]
    public void BinaryTreeTest_MaxDepth_BFS2()
    {
        int?[] root = { 1, null, 2 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int maxDepthBfs = BinaryTree.MaxDepth_BFS(rootTreeNode);
        Assert.That(maxDepthBfs, Is.EqualTo(2));
    }

    #endregion

    #region 110. 平衡二叉树

    [Test]
    public void BinaryTreeTest_IsBalanced()
    {
        int?[] root = { 3, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool isBalanced = BinaryTree.IsBalanced(rootTreeNode);
        Assert.That(isBalanced, Is.EqualTo(true));
    }

    [Test]
    public void BinaryTreeTest_IsBalanced2()
    {
        int?[] root = { 1, 2, 2, 3, 3, null, null, 4, 4 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        bool isBalanced = BinaryTree.IsBalanced(rootTreeNode);
        Assert.That(isBalanced, Is.EqualTo(false));
    }

    #endregion

    #region 124.最大路径和

    [Test]
    public void BinaryTreeTest_MaxPathSum()
    {
        int?[] root = { 1, 2, 3 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int maxPathSum = BinaryTree.MaxPathSum(rootTreeNode);
        Assert.That(maxPathSum, Is.EqualTo(6));
    }

    [Test]
    public void BinaryTreeTest_MaxPathSum2()
    {
        int?[] root = { -10, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        int maxPathSum = BinaryTree.MaxPathSum(rootTreeNode);
        Assert.That(maxPathSum, Is.EqualTo(42));
    }

    #endregion

    #region 236.二叉树的最近公共祖先

    [Test]
    public void BinaryTreeTest_LowestCommonAncestor()
    {
        int?[] root = { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode lowestCommonAncestor = BinaryTree.LowestCommonAncestor(rootTreeNode, rootTreeNode.left, rootTreeNode.right);
        Assert.That(lowestCommonAncestor, Is.EqualTo(rootTreeNode));
    }

    [Test]
    public void BinaryTreeTest_LowestCommonAncestor2()
    {
        int?[] root = { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode lowestCommonAncestor = BinaryTree.LowestCommonAncestor(rootTreeNode, rootTreeNode.left, rootTreeNode.left.right.right);
        Assert.That(lowestCommonAncestor, Is.EqualTo(rootTreeNode.left));
    }

    [Test]
    public void BinaryTreeTest_LowestCommonAncestor3()
    {
        int?[] root = { 1, 2 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode lowestCommonAncestor = BinaryTree.LowestCommonAncestor(rootTreeNode, rootTreeNode, rootTreeNode.left);
        Assert.That(lowestCommonAncestor, Is.EqualTo(rootTreeNode));
    }

    #endregion

    #region 102.二叉树的层序遍历

    [Test]
    public void BinaryTreeTest_LevelOrder()
    {
        int?[] root = { 3, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<IList<int?>> levelOrder = BinaryTree.LevelOrder(rootTreeNode);
        Assert.That(levelOrder, Is.EqualTo(new List<List<int>> { new List<int> { 3 }, new List<int> { 9, 20 }, new List<int> { 15, 7 } }));
    }

    [Test]
    public void BinaryTreeTest_LevelOrder2()
    {
        int?[] root = { 1 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<IList<int?>> levelOrder = BinaryTree.LevelOrder(rootTreeNode);
        Assert.That(levelOrder, Is.EqualTo(new List<List<int>> { new List<int> { 1 } }));
    }

    [Test]
    public void BinaryTreeTest_LevelOrder3()
    {
        int?[] root = Array.Empty<int?>();
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<IList<int?>> levelOrder = BinaryTree.LevelOrder(rootTreeNode);
        Assert.That(levelOrder, Is.EqualTo(new List<List<int>>()));
    }

    #endregion

    #region 107.二叉树的层序遍历II

    [Test]
    public void BinaryTreeTest_LevelOrderBottom()
    {
        int?[] root = { 3, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<IList<int?>> levelOrder = BinaryTree.LevelOrderBottom(rootTreeNode);
        Assert.That(levelOrder, Is.EqualTo(new List<List<int>> { new List<int> { 15, 7 }, new List<int> { 9, 20 }, new List<int> { 3 } }));
    }

    [Test]
    public void BinaryTreeTest_LevelOrderBottom2()
    {
        int?[] root = { 1 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<IList<int?>> levelOrder = BinaryTree.LevelOrderBottom(rootTreeNode);
        Assert.That(levelOrder, Is.EqualTo(new List<List<int>> { new List<int> { 1 } }));
    }

    [Test]
    public void BinaryTreeTest_LevelOrderBottom3()
    {
        int?[] root = Array.Empty<int?>();
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<IList<int?>> levelOrder = BinaryTree.LevelOrderBottom(rootTreeNode);
        Assert.That(levelOrder, Is.EqualTo(new List<List<int>>()));
    }

    #endregion

    #region 103.二叉树的锯齿形层序遍历

    [Test]
    public void BinaryTreeTest_ZigzagLevelOrder()
    {
        int?[] root = { 3, 9, 20, null, null, 15, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<IList<int?>> levelOrder = BinaryTree.ZigzagLevelOrder(rootTreeNode);
        Assert.That(levelOrder, Is.EqualTo(new List<List<int>> { new List<int> { 3 }, new List<int> { 20, 9 }, new List<int> { 15, 7 } }));
    }

    [Test]
    public void BinaryTreeTest_ZigzagLevelOrder2()
    {
        int?[] root = { 1 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<IList<int?>> levelOrder = BinaryTree.ZigzagLevelOrder(rootTreeNode);
        Assert.That(levelOrder, Is.EqualTo(new List<List<int>> { new List<int> { 1 } }));
    }

    [Test]
    public void BinaryTreeTest_ZigzagLevelOrder3()
    {
        int?[] root = Array.Empty<int?>();
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        IList<IList<int?>> levelOrder = BinaryTree.ZigzagLevelOrder(rootTreeNode);
        Assert.That(levelOrder, Is.EqualTo(new List<List<int>>()));
    }

    #endregion

    #region 701. 二叉搜索树中的插入操作

    [Test]
    public void BinaryTreeTest_InsertIntoBST()
    {
        int?[] root = { 4, 2, 7, 1, 3 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode levelOrder = BinaryTree.InsertIntoBST(rootTreeNode, 5);
        Assert.That(BinaryTreeBuilder.ToList(levelOrder), Is.AnyOf(new List<int?> { 4, 2, 7, 1, 3, 5 }, new List<int?> { 5, 2, 7, 1, 3, null, null, null, null, null, 4 }));
    }

    [Test]
    public void BinaryTreeTest_InsertIntoBST2()
    {
        int?[] root = { 40, 20, 60, 10, 30, 50, 70 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode levelOrder = BinaryTree.InsertIntoBST(rootTreeNode, 25);
        Assert.That(BinaryTreeBuilder.ToList(levelOrder), Is.EqualTo(new List<int?> { 40, 20, 60, 10, 30, 50, 70, null, null, 25 }));
    }

    #endregion

    #region 450.删除二叉搜索树中的节点

    [Test]
    public void BinaryTreeTest_DeleteNode()
    {
        int?[] root = { 5, 3, 6, 2, 4, null, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode result = BinaryTree.DeleteNode(rootTreeNode, 3);
        Assert.That(BinaryTreeBuilder.ToList(result), Is.AnyOf(new List<int?> { 5, 4, 6, 2, null, null, 7 }, new List<int?> { 5, 2, 6, null, 4, null, 7 }));
    }

    [Test]
    public void BinaryTreeTest_DeleteNode2()
    {
        int?[] root = { 5, 3, 6, 2, 4, null, 7 };
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode result = BinaryTree.DeleteNode(rootTreeNode, 0);
        Assert.That(BinaryTreeBuilder.ToList(result), Is.EqualTo(new List<int?> { 5, 3, 6, 2, 4, null, 7 }));
    }

    [Test]
    public void BinaryTreeTest_DeleteNode3()
    {
        int?[] root = Array.Empty<int?>();
        TreeNode rootTreeNode = BinaryTreeBuilder.Builder(root);
        TreeNode result = BinaryTree.DeleteNode(rootTreeNode, 0);
        Assert.That(BinaryTreeBuilder.ToList(result), Is.EqualTo(new List<int?>()));
    }

    #endregion
}
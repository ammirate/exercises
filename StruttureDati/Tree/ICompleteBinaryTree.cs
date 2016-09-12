/**
* ITA - Un albero binario completo è un albero binario in cui ogni livello, fino
* al penultimo, è completamente riempito. L'ultimo livello è riempito da
* sinistra a destra.
*
* ENG - A complete binary tree is a tree with every level, except the latter one,
* had the max number of children. The latter level is filled from left to right.
*/
public interface ICompleteBinaryTree<T> : IBinaryTree<T> {

    /// <summary>
    /// Add a node to the latter level, from left to right
    /// </summary>
    /// <param name="el">The value the new node will contain.</param>
    /// <returns>The new position related to the node just created.</returns>
    IPosition<T> add(T el);


    /// <summary>
    /// Remove the last node, from right to left, in the latter level of the tree.
    /// </summary>
    /// <returns>The removed node's value.</returns>
    T remove();
}

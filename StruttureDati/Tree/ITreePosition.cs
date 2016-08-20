using StruttureDati.ListeConcatenate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati.Tree {

    public interface ITreePosition<T> : IPosition<T> {

        void setElement(T element);

        void setParent(ITreePosition<T> parent);

        ITreePosition<T> getParent();

        void setChildren(IPositionList<ITreePosition<T>> children);

        IPositionList<ITreePosition<T>> getChildren();
    }
}
